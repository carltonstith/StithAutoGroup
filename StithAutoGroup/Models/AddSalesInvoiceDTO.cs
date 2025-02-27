using StithAutoGroup.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StithAutoGroup.Models
{
    public class AddSalesInvoiceDTO
    {
        public List<Vehicle>? Vehicles { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<Salesperson>? Salespersons { get; set; }
        //public int Vehicle_Id { get; set; }
        //public int Customer_Id { get; set; }
        //public int Salesperson_Id { get; set; }
        public int Invoice_Number { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Sale_Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime Sale_Date { get; set; }
    }
}
