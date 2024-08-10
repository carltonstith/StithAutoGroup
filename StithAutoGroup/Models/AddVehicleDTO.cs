using System.ComponentModel.DataAnnotations;

namespace StithAutoGroup.Models
{
    public class AddVehicleDTO
    {
        //[Key]
        //public int Vehicle_Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public bool VehicleForSale { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
    }
}
