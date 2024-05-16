using BulldozerServer.Domain.MarketplacePosts;
using Microsoft.EntityFrameworkCore;

namespace BulldozerServer.Domain
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MarketplacePost> MarketplacePosts { get; set; }
        public DbSet<FixedPricePost> FixedPricePosts { get; set; }
        public DbSet<AuctionPost> AuctionPosts { get; set; }
        public DbSet<DonationPost> DonationPosts { get; set; }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<JoinRequest> JoinRequests { get; set; }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Group>().HasKey(g => g.GroupId);
            modelBuilder.Entity<MarketplacePost>().HasKey(mp => mp.MarketplacePostId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Group)
                .WithMany(g => g.MarketplacePosts)
                .HasForeignKey(mp => mp.GroupId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Author)
                .WithMany(u => u.MarketplacePosts)
                .HasForeignKey(mp => mp.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PostsInCart)
                .WithMany(mp => mp.PeopleThatPlacedInCart)
                .UsingEntity("Cart");

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoritePosts)
                .WithMany(mp => mp.PeopleThatFavored)
                .UsingEntity("PostFavors");
        }
        #endregion

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
