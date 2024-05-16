using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulldozerServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateDifferentPostTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentBidPrice",
                table: "MarketplacePost",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentDonationAmount",
                table: "MarketplacePost",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentPriceLeader",
                table: "MarketplacePost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryType",
                table: "MarketplacePost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MarketplacePost",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "DonationLink",
                table: "MarketplacePost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNegotiable",
                table: "MarketplacePost",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinimumBidPrice",
                table: "MarketplacePost",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "MarketplacePost",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBidPrice",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "CurrentDonationAmount",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "CurrentPriceLeader",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "DeliveryType",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "DonationLink",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "IsNegotiable",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "MinimumBidPrice",
                table: "MarketplacePost");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MarketplacePost");
        }
    }
}
