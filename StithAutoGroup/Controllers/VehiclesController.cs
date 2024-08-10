using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var allVehicles = dbContext.Vehicles.ToList();

            return Ok(allVehicles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = dbContext.Vehicles.Find(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult AddVehicle([FromBody] AddVehicleDTO addVehicleDto)
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
            dbContext.Vehicles.Add(vehicleEntity);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllVehicles), new { id = vehicleEntity.Vehicle_Id }, vehicleEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] UpdateVehicleDto updateVehicleDto)
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
            
            dbContext.SaveChanges();

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
