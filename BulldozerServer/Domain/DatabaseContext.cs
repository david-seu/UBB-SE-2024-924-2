using Microsoft.EntityFrameworkCore;
using System;

namespace BulldozerServer.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Group> Group { get; set; }
    }
}
