using StithAutoGroup.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StithAutoGroup.Dtos
{
    public class SalesInvoiceDto
    {
        public int Sales_Invoice_Id { get; set; }
        public int Invoice_Number { get; set; }
        public decimal Sale_Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime Sale_Date { get; set; }
        public List<VehicleDto>? Vehicles { get; set; } 
        public List<CustomerDto>? Customers { get; set; } 
        public List<SalespersonDto>? Salespersons { get; set; }
    }
}
