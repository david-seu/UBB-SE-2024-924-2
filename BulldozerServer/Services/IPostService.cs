using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payloads.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public interface IPostService
    {
        MarketplacePostDTO AddMarketplacePost(MarketplacePostDTO marketplacePostDTO);
        Task<MarketplacePost> GetMarketplacePostById(Guid id);
        Task<ActionResult<IEnumerable<MarketplacePost>>> GetMarketplacePosts();
        Task<EntityEntry> RemoveMarketplacePost(MarketplacePostDTO marketplacePostDTO);
    }
}