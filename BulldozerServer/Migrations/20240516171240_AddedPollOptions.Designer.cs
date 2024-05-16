﻿// <auto-generated />
using System;
using BulldozerServer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulldozerServer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240516171240_AddedPollOptions")]
    partial class AddedPollOptions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulldozerServer.Domain.Cart", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MarketplacePostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AllowanceOfPostage")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BulldozerServer.Domain.JoinRequest", b =>
                {
                    b.Property<Guid>("JoinRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JoinRequestId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("JoinRequests");
                });

            modelBuilder.Entity("BulldozerServer.Domain.MarketplacePosts.MarketplacePost", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPromoted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("MarketplacePostId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GroupId");

                    b.ToTable("MarketplacePosts");

                    b.HasDiscriminator<string>("Type").HasValue("NormalPost");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BulldozerServer.Domain.Membership", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTimedOut")
                        .HasColumnType("bit");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Poll", b =>
                {
                    b.Property<Guid>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMultipleChoice")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.HasKey("PollId");

                    b.HasIndex("GroupId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("BulldozerServer.Domain.PollOption", b =>
                {
                    b.Property<Guid>("PollOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PollId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PollOptionId");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("BulldozerServer.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BulldozerServer.Domain.UsersFavoritePosts", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MarketplacePostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersFavoritePosts");
                });

            modelBuilder.Entity("BulldozerServer.Domain.MarketplacePosts.DonationPost", b =>
                {
                    b.HasBaseType("BulldozerServer.Domain.MarketplacePosts.MarketplacePost");

                    b.Property<double>("CurrentDonationAmount")
                        .HasColumnType("float");

                    b.Property<string>("DonationLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Donation");
                });

            modelBuilder.Entity("BulldozerServer.Domain.MarketplacePosts.FixedPricePost", b =>
                {
                    b.HasBaseType("BulldozerServer.Domain.MarketplacePosts.MarketplacePost");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNegotiable")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("FixedPrice");
                });

            modelBuilder.Entity("BulldozerServer.Domain.MarketplacePosts.AuctionPost", b =>
                {
                    b.HasBaseType("BulldozerServer.Domain.MarketplacePosts.FixedPricePost");

                    b.Property<double>("CurrentBidPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("CurrentPriceLeader")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MinimumBidPrice")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Auction");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Cart", b =>
                {
                    b.HasOne("BulldozerServer.Domain.MarketplacePosts.MarketplacePost", null)
                        .WithMany()
                        .HasForeignKey("MarketplacePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulldozerServer.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulldozerServer.Domain.Group", b =>
                {
                    b.HasOne("BulldozerServer.Domain.User", "Owner")
                        .WithMany("OwnedGroups")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BulldozerServer.Domain.JoinRequest", b =>
                {
                    b.HasOne("BulldozerServer.Domain.Group", "Group")
                        .WithMany("JoinRequests")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulldozerServer.Domain.User", "User")
                        .WithMany("JoinRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BulldozerServer.Domain.MarketplacePosts.MarketplacePost", b =>
                {
                    b.HasOne("BulldozerServer.Domain.User", "Author")
                        .WithMany("MarketplacePosts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BulldozerServer.Domain.Group", "Group")
                        .WithMany("MarketplacePosts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Membership", b =>
                {
                    b.HasOne("BulldozerServer.Domain.Group", "Group")
                        .WithMany("Memberships")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulldozerServer.Domain.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Poll", b =>
                {
                    b.HasOne("BulldozerServer.Domain.Group", "Group")
                        .WithMany("GroupPolls")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BulldozerServer.Domain.PollOption", b =>
                {
                    b.HasOne("BulldozerServer.Domain.Poll", "Poll")
                        .WithMany("PollOptions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("BulldozerServer.Domain.UsersFavoritePosts", b =>
                {
                    b.HasOne("BulldozerServer.Domain.MarketplacePosts.MarketplacePost", null)
                        .WithMany()
                        .HasForeignKey("MarketplacePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulldozerServer.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulldozerServer.Domain.Group", b =>
                {
                    b.Navigation("GroupPolls");

                    b.Navigation("JoinRequests");

                    b.Navigation("MarketplacePosts");

                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("BulldozerServer.Domain.Poll", b =>
                {
                    b.Navigation("PollOptions");
                });

            modelBuilder.Entity("BulldozerServer.Domain.User", b =>
                {
                    b.Navigation("JoinRequests");

                    b.Navigation("MarketplacePosts");

                    b.Navigation("Memberships");

                    b.Navigation("OwnedGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
