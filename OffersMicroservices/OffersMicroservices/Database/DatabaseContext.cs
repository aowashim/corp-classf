using Microsoft.EntityFrameworkCore;
using OffersMicroservices.Database.Entities;

namespace OffersMicroservices.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Comment> Comment { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=MSI;Initial Catalog=CorpClassf;Integrated Security=True");
        //}
    }

}
