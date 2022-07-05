using Microsoft.EntityFrameworkCore;
using OffersMicroservices.Database;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMicroservice.Database.Entities
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public int Points_Gained { get; set; }
        public string Office_Location { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
