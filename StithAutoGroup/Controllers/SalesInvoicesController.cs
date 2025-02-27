using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StithAutoGroup.Data;
using StithAutoGroup.Dtos;
using StithAutoGroup.Models;
using StithAutoGroup.Models.Entities;

namespace StithAutoGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInvoicesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SalesInvoicesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesInvoice>>> GetAllSalesInvoices()
        {
            //var allSalesInvoices = SalesInvoiceDataStore.Current.SalesInvoices;
            var allSalesInvoices = await dbContext.Sales_Invoices
                .Include(x => x.Salespersons)
                //.Include(c => c.Customers)
                //.Include(v => v.Vehicles)
                .ToListAsync();

            return Ok(allSalesInvoices);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<SalesInvoiceDto>> GetSalesInvoiceById(int id)
        {
            //var salesInvoice = dbContext.Sales_Invoices.Find(id);
            var salesInvoice = SalesInvoiceDataStore.Current.Sales_Invoices.FirstOrDefault(s => s.Sales_Invoice_Id == id);

            if (salesInvoice == null)
            {
                return NotFound();
            }

            return Ok(salesInvoice);
        }

        //[HttpPost]
        //public IActionResult AddSalesInvoice([FromBody] AddSalesInvoiceDTO addSalesInvoiceDto)
        //{
        //    var salesInvoiceEntity = new SalesInvoice
        //    {
        //        Vehicles = addSalesInvoiceDto.Vehicles,
        //        Customers = addSalesInvoiceDto.Customers,
        //        Salespersons = addSalesInvoiceDto.Salespersons,
        //        Invoice_Number = addSalesInvoiceDto.Invoice_Number,
        //        Sale_Price = addSalesInvoiceDto.Sale_Price,
        //        Tax = addSalesInvoiceDto.Tax,
        //        Total = addSalesInvoiceDto.Total,
        //        Sale_Date = addSalesInvoiceDto.Sale_Date
        //    };
        //    dbContext.Sales_Invoices.Add(salesInvoiceEntity);
        //    dbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
