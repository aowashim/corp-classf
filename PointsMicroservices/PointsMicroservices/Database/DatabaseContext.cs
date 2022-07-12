using Microsoft.EntityFrameworkCore;
using PointsMicroservices.Database.Entities;

namespace PointsMicroservices.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=owashim\sqlexpress;Initial Catalog=CorpClassf;Integrated Security=True");
        }
    }
}
