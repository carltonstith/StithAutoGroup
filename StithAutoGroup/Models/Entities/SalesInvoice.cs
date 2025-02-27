using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StithAutoGroup.Models.Entities
{
    public class SalesInvoice
    {
        [Key]
        public int Sales_Invoice_Id { get; set; }
        public int Invoice_Number { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Sale_Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime Sale_Date { get; set; }

        //public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
      
        //public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public ICollection<Salesperson> Salespersons { get; set; } = new List<Salesperson>();

        //public SalesInvoice(int invoicenumber)
        //{
        //    Invoice_Number = invoicenumber;
        //}

        //public int Vehicle_Id { get; set; }
        //[ForeignKey("Vehicle_Id")]
        //public Vehicle? Vehicle { get; set; }
        //public int Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public List<Customer>? Customers { get; set; } = new List<Customer>();
        //public int Salesperson_Id { get; set; }
        //[ForeignKey("Salesperson_Id")]
        //public List<Salesperson>? Salespersons { get; set; } = new List<Salesperson>();
    }
}
