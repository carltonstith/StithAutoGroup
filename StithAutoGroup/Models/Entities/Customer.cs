﻿using System.ComponentModel.DataAnnotations;

namespace StithAutoGroup.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip_Code { get; set; }
    }
}
