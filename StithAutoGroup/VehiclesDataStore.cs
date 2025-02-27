using StithAutoGroup.Dtos;

namespace StithAutoGroup
{
    public class VehiclesDataStore
    {
        public List<VehicleDto> Vehicles { get; set; }

        public static VehiclesDataStore Current { get; } = new VehiclesDataStore();

        public VehiclesDataStore()
        {
            Vehicles = new List<VehicleDto>()
            {
                new VehicleDto()
                {
                    Vehicle_Id = 1,
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2019,
                    Color = "White",
                    Price = 20000
                },
                new VehicleDto()
                {
                    Vehicle_Id = 2,
                    Make = "Ford",
                    Model = "F-150",
                    Year = 2020,
                    Color = "Black",
                    Price = 35000
                },
                new VehicleDto()
                {
                    Vehicle_Id = 3,
                    Make = "Chevrolet",
                    Model = "Silverado",
                    Year = 2021,
                    Color = "Red",
                    Price = 40000
                }
            };
        }
    }
}
