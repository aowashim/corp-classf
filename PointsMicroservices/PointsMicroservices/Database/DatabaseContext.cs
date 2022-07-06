using Microsoft.EntityFrameworkCore;
using PointsMicroservices.Database.Entities;

namespace PointsMicroservices.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Point> Points { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=MSI; initial catalog=PointDataBase; Integrated Security=true");
        }
    }
}
