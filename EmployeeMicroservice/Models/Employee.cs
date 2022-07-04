using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMicroservice.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public int Points_Gained { get; set; }
        public string Office_Location { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }  
    }
}
