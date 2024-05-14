using Microsoft.EntityFrameworkCore;

namespace BulldozerServer.Domain
{
    public class DatabaseContext : DbContext    
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

    }
}
