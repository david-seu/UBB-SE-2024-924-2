using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payloads.DTO;

namespace BulldozerServer.Mapper
{
    public class MarketplacePostMapper
    {
        public static MarketplacePostDTO MapMarketplacePostToMarketplacePostDTO(MarketplacePost marketplacePost)
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
            return marketplacePostDTO;
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
    }
}
