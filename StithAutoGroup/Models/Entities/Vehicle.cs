using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StithAutoGroup.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public int Vehicle_Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public bool VehicleForSale { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
    }
}
