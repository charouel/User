using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserApi.Domain.Entities;

namespace UserApi.Infrastrecture.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        // Injection de IConfiguration pour accéder à la chaîne de connexion
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<User> Users { get; set; }  // Exemple de table
    }
}
