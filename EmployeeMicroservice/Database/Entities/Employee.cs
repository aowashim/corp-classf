using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMicroservice.Database.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public int Points_Gained { get; set; }
        public string Office_Location { get; set; }
        public int EmpId { get; set; }
    }
}
