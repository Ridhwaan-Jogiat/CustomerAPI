using Microsoft.EntityFrameworkCore;
using CustomerAPI.Models;

namespace CustomerAPI.Data
{
    //tells EF Core how to interact with the database
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.AmountTotal)
                .HasColumnType("decimal(18,2)");

            // jsut some Sample data
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Ridhwaan",
                    Surname = "Jogiat",
                    Email = "ridhwaan.jogiat@gmail.com",
                    Cellphone = "0619015630",
                    Type = "Person",
                    AmountTotal = 3000
                }
            );
        }
    }
}