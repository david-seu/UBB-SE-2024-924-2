using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Domain;
using Microsoft.AspNetCore.Identity.Data;
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

        // public DbSet<JoinRequest> JoinRequests { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<UsersFavoritePosts> UsersFavoritePosts { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Group>().HasKey(g => g.GroupId);
            modelBuilder.Entity<MarketplacePost>().HasKey(mp => mp.MarketplacePostId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Owner)
                .WithMany(u => u.OwnedGroups)
                .HasForeignKey(g => g.OwnerId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Group)
                .WithMany(g => g.MarketplacePosts)
                .HasForeignKey(mp => mp.GroupId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Author)
                .WithMany(u => u.MarketplacePosts)
                .HasForeignKey(mp => mp.AuthorId);

            modelBuilder.Entity<MarketplacePost>()
                .HasDiscriminator<string>("Type")
                .HasValue<FixedPricePost>(Constants.FIXED_PRICE_POST_TYPE)
                .HasValue<AuctionPost>(Constants.AUCTION_POST_TYPE)
                .HasValue<DonationPost>(Constants.DONATION_POST_TYPE)
                .HasValue<MarketplacePost>(Constants.DEFAULT_POST_TYPE);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PostsInCart)
                .WithMany(mp => mp.PeopleThatPlacedInCart)
                .UsingEntity<Cart>(
                    l => l.HasOne<MarketplacePost>().WithMany().HasForeignKey(e => e.MarketplacePostId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId));

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoritePosts)
                .WithMany(mp => mp.PeopleThatFavored)
                .UsingEntity<UsersFavoritePosts>(
                    l => l.HasOne<MarketplacePost>().WithMany().HasForeignKey(e => e.MarketplacePostId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId));

            modelBuilder.Entity<Membership>().HasKey(m => new { m.GroupId, m.UserId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.GroupsPartOf)
                .WithMany(g => g.Users)
                .UsingEntity<Membership>();

            // modelBuilder.Entity<Membership>
        }
        #endregion

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}