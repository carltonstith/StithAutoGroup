using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StithAutoGroup.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StithAutoGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly IConfiguration configuration;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            //model.Role = "Customer";
            var applicationUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash!);
                if (result.Succeeded)
                    return Ok(result);

                return BadRequest(result);
                //return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // create token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserID", user.Id.ToString()),
                    new Claim("Email", user.Email.ToString()),
                    new Claim("AutoGroupRole", user.AutoGroupRole.ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //generate token
                var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    //expires: DateTime.UtcNow.AddMinutes(1),//testing purposes ONLY
                    signingCredentials: signIn
                );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new Claim[]
                //    {
                //        new Claim("UserID", user.Id.ToString()),
                //        //new Claim("AutoGroupRole", user.AutoGroupRole.ToString())
                //    }),
                //    Expires = DateTime.UtcNow.AddDays(1),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                //};
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                //var token = tokenHandler.WriteToken(securityToken);
                //return Ok(new 
                //{  
                //    Id = user.Id,
                //    UserName = user.UserName,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    //AutoGroupRole = user.AutoGroupRole,
                //    //AutoGroupEmployee = user.AutoGroupEmployee,
                //    //AutoGroupUserLink = user.AutoGroupUserLink,
                //    Token = token
                //}); //these will return in a JSON object after a successfull login
                return Ok(new { Token = tokenValue, User = user });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        //[HttpGet("{id}")]
        //[Route("GetUser")]
        ////GET : /api/ApplicationUser/GetUser
        //public async Task<ActionResult<ApplicationUser>> GetUser(int id)
        //{
        //    var user = await _userManager.FindByIdAsync(id.ToString());
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return user;
        //}
    }
}
