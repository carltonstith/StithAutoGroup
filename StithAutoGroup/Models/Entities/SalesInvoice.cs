using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StithAutoGroup.Models.Entities
{
    public class SalesInvoice
    {
        [Key]
        public int Sales_Invoice_Id { get; set; }
        //public IEnumerable<Vehicle> Vehicles { get; set; }
        //public IEnumerable<Customer> Customers { get; set; }
        //public IEnumerable<Salesperson> Salespersons { get; set; }
        public int Vehicle_Id { get; set; }
        public int Customer_Id { get; set; }
        public int Salesperson_Id { get; set; }
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
