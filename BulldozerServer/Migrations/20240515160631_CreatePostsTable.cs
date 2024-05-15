using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulldozerServer.Migrations
{
    /// <inheritdoc />
    public partial class CreatePostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketplacePost",
                columns: table => new
                {
                    MarketplacePostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPromoted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplacePost", x => x.MarketplacePostId);
                    table.ForeignKey(
                        name: "FK_MarketplacePost_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketplacePost_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    PeopleThatPlacedInCartUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostsInCartMarketplacePostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.PeopleThatPlacedInCartUserId, x.PostsInCartMarketplacePostId });
                    table.ForeignKey(
                        name: "FK_Cart_MarketplacePost_PostsInCartMarketplacePostId",
                        column: x => x.PostsInCartMarketplacePostId,
                        principalTable: "MarketplacePost",
                        principalColumn: "MarketplacePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_User_PeopleThatPlacedInCartUserId",
                        column: x => x.PeopleThatPlacedInCartUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostFavors",
                columns: table => new
                {
                    FavoritePostsMarketplacePostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeopleThatFavoredUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFavors", x => new { x.FavoritePostsMarketplacePostId, x.PeopleThatFavoredUserId });
                    table.ForeignKey(
                        name: "FK_PostFavors_MarketplacePost_FavoritePostsMarketplacePostId",
                        column: x => x.FavoritePostsMarketplacePostId,
                        principalTable: "MarketplacePost",
                        principalColumn: "MarketplacePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostFavors_User_PeopleThatFavoredUserId",
                        column: x => x.PeopleThatFavoredUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PostsInCartMarketplacePostId",
                table: "Cart",
                column: "PostsInCartMarketplacePostId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplacePost_AuthorId",
                table: "MarketplacePost",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplacePost_GroupId",
                table: "MarketplacePost",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFavors_PeopleThatFavoredUserId",
                table: "PostFavors",
                column: "PeopleThatFavoredUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "PostFavors");

            migrationBuilder.DropTable(
                name: "MarketplacePost");
        }
    }
}
