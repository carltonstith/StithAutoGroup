using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StithAutoGroup.Data;
using StithAutoGroup.Models;
using StithAutoGroup.Models.Entities;

namespace StithAutoGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalespersonController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SalespersonController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Salesperson>>> GetAllSalespeople()
        {
            var allSalespeople = await dbContext.Salespersons.ToListAsync();

            return Ok(allSalespeople);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Salesperson>> GetSalespersonById(int id)
        {
            var salesperson = await dbContext.Salespersons.FindAsync(id);

            if (salesperson is null)
                return NotFound();

            return Ok(salesperson);
        }

        [HttpPost]
        public async Task<ActionResult<List<Salesperson>>> AddSalesperson([FromBody] AddSalespersonDto addSalespersonDto)
        {
            var salespersonEntity = new Salesperson
            {
                First_Name = addSalespersonDto.First_Name,
                Last_Name = addSalespersonDto.Last_Name,
                Email = addSalespersonDto.Email
            };
            dbContext.Salespersons.Add(salespersonEntity);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllSalespeople), new { id = salespersonEntity.Salesperson_Id }, salespersonEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Salesperson>>> UpdateSalesperson(int id, [FromBody] UpdateSalespersonDto updateSalespersonDto)
        {
            var salesperson = dbContext.Salespersons.Find(id);

            if (salesperson == null)
            {
                return NotFound();
            }

            salesperson.First_Name = updateSalespersonDto.First_Name;
            salesperson.Last_Name = updateSalespersonDto.Last_Name;
            salesperson.Email = updateSalespersonDto.Email;

            await dbContext.SaveChangesAsync();

            return Ok(salesperson);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSalesperson(int id)
        {
            var salesperson = dbContext.Salespersons.Find(id);

            if (salesperson == null)
            {
                return NotFound();
            }

            dbContext.Salespersons.Remove(salesperson);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
