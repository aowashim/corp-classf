using Microsoft.EntityFrameworkCore;
using EmployeeMicroservice.Database.Entities;

namespace EmployeeMicroservice.Database
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        { }

        //public EmployeeContext() { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
