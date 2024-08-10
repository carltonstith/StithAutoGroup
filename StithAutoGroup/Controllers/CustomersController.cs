using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StithAutoGroup.Data;
using StithAutoGroup.Models;
using StithAutoGroup.Models.Entities;

namespace StithAutoGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CustomersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = dbContext.Customers.ToList();
            // get 10 customers
            //var allCustomers = dbContext.Customers.Take(10).ToList();
            return Ok(allCustomers);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCustomerById(int id) 
        {
            var customer = dbContext.Customers.Find(id);

            if (customer == null) 
            { 
                return  NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] AddCustomerDto addCustomerDto)
        {
            var customerEntity = new Customer
            {
                First_Name = addCustomerDto.First_Name,
                Last_Name = addCustomerDto.Last_Name,
                Phone_Number = addCustomerDto.Phone_Number,
                Address = addCustomerDto.Address,
                City = addCustomerDto.City,
                State = addCustomerDto.State,
                Country = addCustomerDto.Country,
                Zip_Code = addCustomerDto.Zip_Code
            };
            dbContext.Customers.Add(customerEntity);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllCustomers), new { id = customerEntity.Customer_Id }, customerEntity);
            //return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var customer = dbContext.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.First_Name = updateCustomerDto.First_Name;
            customer.Last_Name = updateCustomerDto.Last_Name;
            customer.Phone_Number = updateCustomerDto.Phone_Number;
            customer.Address = updateCustomerDto.Address;
            customer.City = updateCustomerDto.City;
            customer.State = updateCustomerDto.State;
            customer.Country = updateCustomerDto.Country;
            customer.Zip_Code = updateCustomerDto.Zip_Code;

            dbContext.SaveChanges();

            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
