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
            MarketplacePost marketplacePost = new MarketplacePost(Guid.NewGuid(), (Guid)marketplacePostDTO.AuthorId, marketplacePostDTO.GroupId, marketplacePostDTO.Title, marketplacePostDTO.Description, marketplacePostDTO.MediaContent, marketplacePostDTO.Location, marketplacePostDTO.CreationDate, marketplacePostDTO.EndDate, marketplacePostDTO.IsPromoted, marketplacePostDTO.IsActive, marketplacePostDTO.Type);
            return marketplacePost;
        }
    }
}
