using System.ComponentModel.DataAnnotations;

namespace StithAutoGroup.Models.Entities
{
    public class Salesperson
    {
        [Key]
        public int Salesperson_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
    }
}
