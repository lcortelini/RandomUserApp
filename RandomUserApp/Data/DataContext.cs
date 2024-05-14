using Microsoft.EntityFrameworkCore;
using RandomUserApp.Models;

namespace RandomUserApp.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebAppDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APPConfiguration>().HasData(
                new APPConfiguration
                {
                    ID = 1,
                    BaseAddress = "https://api.randomuser.me",
                    ApiURL = "https://randomuser.me/api/"
                });
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<APPConfiguration> APPConfiguration { get; set; }
    }
}
