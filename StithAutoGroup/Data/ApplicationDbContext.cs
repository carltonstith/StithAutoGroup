using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StithAutoGroup.Models.Entities;

namespace StithAutoGroup.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salesperson> Salespersons { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
    }
    //public class ApplicationDbContext : DbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //    {
    //    }

    //    public DbSet<Vehicle> Vehicles { get; set; }
    //    public DbSet<Customer> Customers { get; set; }
    //    public DbSet<Salesperson> Salespersons{ get; set; }
    //    public DbSet<SalesInvoice> SalesInvoices { get; set; }
    //}
}
