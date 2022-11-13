using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using worker_mngmt.Models;

namespace worker_mngmt.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Org> Orgs { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(AppDbContext databaseContext)
        {
            if (databaseContext.Database.EnsureCreated())
            {
                databaseContext.SaveChanges();
            }
        }
    }
}
