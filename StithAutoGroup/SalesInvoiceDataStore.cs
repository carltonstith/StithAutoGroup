using StithAutoGroup.Dtos;

namespace StithAutoGroup
{
    public class SalesInvoiceDataStore
    {
        public List<SalesInvoiceDto> Sales_Invoices { get; set; }

        public static SalesInvoiceDataStore Current { get; } = new SalesInvoiceDataStore();

        public SalesInvoiceDataStore()
        {
            Sales_Invoices = new List<SalesInvoiceDto>()
            {
                new SalesInvoiceDto()
                {
                    Sales_Invoice_Id = 1,
                    Invoice_Number = 1,
                    Sale_Price = 20000,
                    Tax = 2000,
                    Total = 22000,
                    Sale_Date = new DateTime(2021, 1, 1),
                    Vehicles = new List<VehicleDto>()
                    {
                        new VehicleDto()
                        {
                            Vehicle_Id = 628,
                            Make = "Toyota",
                            Model = "Corolla",
                            Year = 2019,
                            Color = "White",
                            VIN = "123456789",
                            VehicleForSale = true,
                            Price = 20000,
                            Mileage = 5000,
                            Engine = "4-cylinder",
                            Transmission = "Automatic"
                        }
                    },
                    Customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            Customer_Id = 969,
                            First_Name = "John",
                            Last_Name = "Doe",
                            Phone_Number = "123-456-7890",
                            Email = "mmuhmad@gmail.com",
                            Address = "123 Main",
                            City = "Dallas",
                            State = "TX",
                            Country = "USA",
                            Zip_Code = "75001"
                        }
                    },
                    Salespersons = new List<SalespersonDto>()
                    {
                        new SalespersonDto()
                        {
                            Salesperson_Id = 357,
                            First_Name = "Jane",
                            Last_Name = "Smith",
                            Email = "driley@gmail.com"
                        } 
                    }
                },
                //new SalesInvoiceDto()
                //{
                //    Sales_Invoice_Id = 2,
                //    Invoice_Number = 2,
                //    Sale_Price = 35000,
                //    Tax = 3500,
                //    Total = 38500,
                //    Sale_Date = new DateTime(2021, 2, 1)
                //},
                //new SalesInvoiceDto()
                //{
                //    Invoice_Number = 3,
                //    Sale_Price = 40000,
                //    Tax = 4000,
                //    Total = 44000,
                //    Sale_Date = new DateTime(2021, 3, 1)
                //}
            };
        }
    }
}
