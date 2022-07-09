using Microsoft.EntityFrameworkCore;
using EmployeeMicroservice.Database.Entities;
using OffersMicroservices.Database;

namespace EmployeeMicroservice.Database
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
