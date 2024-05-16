using Azure.Core;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payload.DTO;
using BulldozerServer.Payloads.DTO;

namespace BulldozerServer.Mapper
{
    public class MarketplacePostMapper
    {
        public static MarketplacePostDTO MapMarketplacePostToMarketplacePostDTO(MarketplacePost marketplacePost)
        {
            switch (marketplacePost)
            {
                case DonationPost donationPost:
                    return MapDonationPostToDTO(donationPost);
                case AuctionPost auctionPost:
                    return MapAuctionPostToDTO(auctionPost);
                case FixedPricePost fixedPricePost:
                    return MapFixedPricePostToDTO(fixedPricePost);
                default:
                    return MapStandardPostToDTO(marketplacePost);
            }
        }
        public static MarketplacePost MapMarketplacePostDTOToMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            MarketplacePost marketplacePost = new MarketplacePost();
            marketplacePost.MarketplacePostId = marketplacePostDTO.MarketplacePostId;
            marketplacePost.AuthorId = marketplacePostDTO.AuthorId;
            marketplacePost.GroupId = marketplacePostDTO.GroupId;
            marketplacePost.Title = marketplacePostDTO.Title;
            marketplacePost.Description = marketplacePostDTO.Description;
            marketplacePost.MediaContent = marketplacePostDTO.MediaContent;
            marketplacePost.Location = marketplacePostDTO.Location;
            marketplacePost.CreationDate = marketplacePostDTO.CreationDate;
            marketplacePost.EndDate = marketplacePostDTO.EndDate;
            marketplacePost.IsPromoted = marketplacePostDTO.IsPromoted;
            marketplacePost.IsActive = marketplacePostDTO.IsActive;
            return marketplacePost;
        }

        private static MarketplacePostDTO MapStandardPostToDTO(MarketplacePost marketplacePost)
        {
            MarketplacePostDTO marketplacePostDTO = new MarketplacePostDTO();
            marketplacePostDTO.MarketplacePostId = marketplacePost.MarketplacePostId;
            marketplacePostDTO.AuthorId = marketplacePost.AuthorId;
            marketplacePostDTO.GroupId = marketplacePost.GroupId;
            marketplacePostDTO.Title = marketplacePost.Title;
            marketplacePostDTO.Description = marketplacePost.Description;
            marketplacePostDTO.MediaContent = marketplacePost.MediaContent;
            marketplacePostDTO.Location = marketplacePost.Location;
            marketplacePostDTO.CreationDate = marketplacePost.CreationDate;
            marketplacePostDTO.EndDate = marketplacePost.EndDate;
            marketplacePostDTO.IsPromoted = marketplacePost.IsPromoted;
            marketplacePostDTO.IsActive = marketplacePost.IsActive;
            marketplacePostDTO.Type = marketplacePost.Type;
            marketplacePostDTO.Author = marketplacePost.Author;
            marketplacePostDTO.Group = marketplacePost.Group;
            marketplacePostDTO.PeopleThatFavored = marketplacePost.PeopleThatFavored;
            marketplacePostDTO.PeopleThatPlacedInCart = marketplacePost.PeopleThatPlacedInCart;
            return marketplacePostDTO;
        }

        private static DonationPostDTO MapDonationPostToDTO(DonationPost donationPost)
        {
            DonationPostDTO donationPostDTO = new DonationPostDTO();
            donationPostDTO.MarketplacePostId = donationPost.MarketplacePostId;
            donationPostDTO.AuthorId = donationPost.AuthorId;
            donationPostDTO.GroupId = donationPost.GroupId;
            donationPostDTO.Title = donationPost.Title;
            donationPostDTO.Description = donationPost.Description;
            donationPostDTO.MediaContent = donationPost.MediaContent;
            donationPostDTO.Location = donationPost.Location;
            donationPostDTO.CreationDate = donationPost.CreationDate;
            donationPostDTO.EndDate = donationPost.EndDate;
            donationPostDTO.IsPromoted = donationPost.IsPromoted;
            donationPostDTO.IsActive = donationPost.IsActive;
            donationPostDTO.Type = donationPost.Type;
            donationPostDTO.Author = donationPost.Author;
            donationPostDTO.Group = donationPost.Group;
            donationPostDTO.PeopleThatFavored = donationPost.PeopleThatFavored;
            donationPostDTO.PeopleThatPlacedInCart = donationPost.PeopleThatPlacedInCart;
            donationPostDTO.DonationLink = donationPost.DonationLink;
            donationPostDTO.CurrentDonationAmount = donationPost.CurrentDonationAmount;
            return donationPostDTO;
        }

        private static FixedPricePostDTO MapFixedPricePostToDTO(FixedPricePost fixedPricePost)
        {
            FixedPricePostDTO fixedPricePostDTO = new FixedPricePostDTO();
            fixedPricePostDTO.MarketplacePostId = fixedPricePost.MarketplacePostId;
            fixedPricePostDTO.AuthorId = fixedPricePost.AuthorId;
            fixedPricePostDTO.GroupId = fixedPricePost.GroupId;
            fixedPricePostDTO.Title = fixedPricePost.Title;
            fixedPricePostDTO.Description = fixedPricePost.Description;
            fixedPricePostDTO.MediaContent = fixedPricePost.MediaContent;
            fixedPricePostDTO.Location = fixedPricePost.Location;
            fixedPricePostDTO.CreationDate = fixedPricePost.CreationDate;
            fixedPricePostDTO.EndDate = fixedPricePost.EndDate;
            fixedPricePostDTO.IsPromoted = fixedPricePost.IsPromoted;
            fixedPricePostDTO.IsActive = fixedPricePost.IsActive;
            fixedPricePostDTO.Type = fixedPricePost.Type;
            fixedPricePostDTO.Author = fixedPricePost.Author;
            fixedPricePostDTO.Group = fixedPricePost.Group;
            fixedPricePostDTO.PeopleThatFavored = fixedPricePost.PeopleThatFavored;
            fixedPricePostDTO.PeopleThatPlacedInCart = fixedPricePost.PeopleThatPlacedInCart;
            fixedPricePostDTO.Price = fixedPricePost.Price;
            fixedPricePostDTO.IsNegotiable = fixedPricePost.IsNegotiable;
            fixedPricePostDTO.DeliveryType = fixedPricePost.DeliveryType;
            return fixedPricePostDTO;
        }

        private static AuctionPostDTO MapAuctionPostToDTO(AuctionPost auctionPost)
        {
            AuctionPostDTO auctionPostDTO = new AuctionPostDTO();
            auctionPostDTO.MarketplacePostId = auctionPost.MarketplacePostId;
            auctionPostDTO.AuthorId = auctionPost.AuthorId;
            auctionPostDTO.GroupId = auctionPost.GroupId;
            auctionPostDTO.Title = auctionPost.Title;
            auctionPostDTO.Description = auctionPost.Description;
            auctionPostDTO.MediaContent = auctionPost.MediaContent;
            auctionPostDTO.Location = auctionPost.Location;
            auctionPostDTO.CreationDate = auctionPost.CreationDate;
            auctionPostDTO.EndDate = auctionPost.EndDate;
            auctionPostDTO.IsPromoted = auctionPost.IsPromoted;
            auctionPostDTO.IsActive = auctionPost.IsActive;
            auctionPostDTO.Type = auctionPost.Type;
            auctionPostDTO.Author = auctionPost.Author;
            auctionPostDTO.Group = auctionPost.Group;
            auctionPostDTO.PeopleThatFavored = auctionPost.PeopleThatFavored;
            auctionPostDTO.PeopleThatPlacedInCart = auctionPost.PeopleThatPlacedInCart;
            auctionPostDTO.Price = auctionPost.Price;
            auctionPostDTO.IsNegotiable = auctionPost.IsNegotiable;
            auctionPostDTO.DeliveryType = auctionPost.DeliveryType;
            auctionPostDTO.CurrentPriceLeader = auctionPost.CurrentPriceLeader;
            auctionPostDTO.CurrentBidPrice = auctionPost.CurrentBidPrice;
            auctionPostDTO.MinimumBidPrice = auctionPost.MinimumBidPrice;
            return auctionPostDTO;
        }
    }
}
