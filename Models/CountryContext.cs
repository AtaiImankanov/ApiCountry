

using Microsoft.EntityFrameworkCore;

namespace WebApplicationCountry.Models
{

    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { 
        }
    }
}
