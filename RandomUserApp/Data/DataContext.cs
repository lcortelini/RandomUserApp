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

        public DbSet<Person> Person { get; set; }

    }
}
