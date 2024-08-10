using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StithAutoGroup.Models.Entities;
using System.Security.Claims;

namespace StithAutoGroup.Infrastructure.ApplicationUserClaims
{
    public class ApplicationUserClaimsPrincipleFactory
    {
        public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
        {
            public ApplicationUserClaimsPrincipalFactory(
                UserManager<ApplicationUser> userManager
                , IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor)
            { }

            public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
            {
                var principal = await base.CreateAsync(user);

                if (!string.IsNullOrWhiteSpace(user.Email))
                {
                    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("Email", user.Email)
                });
                }

                //if (!string.IsNullOrEmpty(user.AfauserLink))
                //{
                //    ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                //    {
                //    new Claim("AfauserLink", user.AfauserLink)
                //});
                //}

                //if (!string.IsNullOrEmpty(user.AutoGroupRole.ToString()))
                //    {
                //        ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                //        {
                //        new Claim("AutoGroupRole", user.AutoGroupRole.ToString())
                //    });
                //}

                //if (!string.IsNullOrEmpty(user.AfaEmployee.ToString()))
                //{
                //    ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                //    {
                //    new Claim("AfaEmployee", user.AfaEmployee.ToString())
                //});
                //}
                // You can add more properties that you want to expose on the User object below

                return principal;
            }
        }
    }
}
//}
