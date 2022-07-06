using System.ComponentModel.DataAnnotations;

namespace PointsMicroservices.Database.Entities
{
    public class Point
    {
        [Key]
        public int Point_Id { get; set; }
        public int Emp_Id { get; set; }
        public int Emp_Point { get; set; }
    }

}
