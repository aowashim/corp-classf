using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsMicroservices.Database.Entities
{
    public class Employee
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string Email { get; set; }
            public string Designation { get; set; }
            public int Points_Gained { get; set; }
            public string Office_Location { get; set; }
   
    }

}
