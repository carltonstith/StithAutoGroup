using Microsoft.AspNetCore.Authorization;
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
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public VehiclesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var allVehicles = await dbContext.Vehicles.ToListAsync();

            return Ok(allVehicles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleDTO addVehicleDto)
        {
            var vehicleEntity = new Vehicle
            {
                Make = addVehicleDto.Make,
                Model = addVehicleDto.Model,
                Year = addVehicleDto.Year,
                Color = addVehicleDto.Color,
                VIN = addVehicleDto.VIN,
                VehicleForSale = addVehicleDto.VehicleForSale,
                Price = addVehicleDto.Price,
                Mileage = addVehicleDto.Mileage,
                Engine = addVehicleDto.Engine,
                Transmission = addVehicleDto.Transmission
            };
            await dbContext.Vehicles.AddAsync(vehicleEntity);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllVehicles), new { id = vehicleEntity.Vehicle_Id }, vehicleEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] UpdateVehicleDto updateVehicleDto)
        {

            var vehicle = dbContext.Vehicles.Find(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Make = updateVehicleDto.Make;
            vehicle.Model = updateVehicleDto.Model;
            vehicle.Year = updateVehicleDto.Year;
            vehicle.Color = updateVehicleDto.Color;
            vehicle.VIN = updateVehicleDto.VIN;
            vehicle.VehicleForSale = updateVehicleDto.VehicleForSale;
            vehicle.Price = updateVehicleDto.Price;
            vehicle.Mileage = updateVehicleDto.Mileage;
            vehicle.Engine = updateVehicleDto.Engine;
            vehicle.Transmission = vehicle.Transmission;
            
            await dbContext.SaveChangesAsync();

            return Ok(vehicle);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = dbContext.Vehicles.Find(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            dbContext.Vehicles.Remove(vehicle);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
