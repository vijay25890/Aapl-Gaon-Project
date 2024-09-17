using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
		
		public DbSet<ApplicationLogs> ApplicationLogs { get; set; }
		public DbSet<Locations> Locations { get; set; }
        // Add-Migration -c ApplicationDbContext
        // Update-Database -Context ApplicationDbContext
    }
}
