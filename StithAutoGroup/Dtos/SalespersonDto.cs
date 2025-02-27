namespace StithAutoGroup.Dtos
{
    public class SalespersonDto
    {
        public int Salesperson_Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }

        public List<SalesInvoiceDto>? SalesInvoices { get; set; }
        public List<CustomerDto>? Customers { get; set; }
    }
}
