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

        public DbSet<JoinRequest> JoinRequests { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<UsersFavoritePosts> UsersFavoritePosts { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }

        public DbSet<GroupPost> GroupPosts { get; set; }
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

            modelBuilder.Entity<JoinRequest>().HasKey(jr => jr.JoinRequestId);

            modelBuilder.Entity<JoinRequest>()
                .HasOne(jr => jr.User)
                .WithMany(u => u.JoinRequests)
                .HasForeignKey(jr => jr.UserId);

            modelBuilder.Entity<JoinRequest>()
                .HasOne(jr => jr.Group)
                .WithMany(g => g.JoinRequests)
                .HasForeignKey(jr => jr.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.UsersTryingToJoin)
                .WithMany(u => u.GroupsTryingToJoin)
                .UsingEntity<JoinRequest>();

            modelBuilder.Entity<Poll>().HasKey(p => p.PollId);

            modelBuilder.Entity<Poll>()
                .HasOne(p => p.Group)
                .WithMany(g => g.GroupPolls)
                .HasForeignKey(p => p.GroupId);

            modelBuilder.Entity<PollOption>().HasKey(po => po.PollOptionId);

            modelBuilder.Entity<PollOption>()
                .HasOne(po => po.Poll)
                .WithMany(p => p.PollOptions)
                .HasForeignKey(po => po.PollId);

            modelBuilder.Entity<PollAnswer>().HasKey(pa => new { pa.PollOptionId, pa.UserId });

            modelBuilder.Entity<PollAnswer>()
                .HasOne(pa => pa.PollOption)
                .WithMany(po => po.PollAnswers)
                .HasForeignKey(pa => pa.PollOptionId);

            modelBuilder.Entity<PollAnswer>()
                .HasOne(pa => pa.UserThatAnswered)
                .WithMany(u => u.PollAnswers)
                .HasForeignKey(pa => pa.UserId);

            modelBuilder.Entity<PollOption>()
                .HasMany(pa => pa.UsersThatSelectedOption)
                .WithMany(u => u.SelectedPollOptions)
                .UsingEntity<PollAnswer>();

            modelBuilder.Entity<GroupPost>()
                .HasKey(gp => gp.GroupPostId);

            modelBuilder.Entity<GroupPost>()
                .HasOne(gp => gp.Group)
                .WithMany(g => g.GroupPosts)
                .HasForeignKey(gp => gp.GroupId);

            modelBuilder.Entity<GroupPost>()
                .HasOne(gp => gp.Author)
                .WithMany(u => u.GroupPosts)
                .HasForeignKey(gp => gp.AuthorId);
        }
        #endregion

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}