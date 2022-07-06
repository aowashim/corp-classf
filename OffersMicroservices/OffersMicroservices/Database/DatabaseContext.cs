using Microsoft.EntityFrameworkCore;

namespace OffersMicroservices.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=LAPTOP-0RNS8QGB;initial catalog=OfferDB;Trusted_Connection=True;");
        }
    }

}
