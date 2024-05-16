using BulldozerServer.Domain.MarketplacePosts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public interface IPostService
    {
        Task<EntityEntry<MarketplacePost>> AddMarketplacePost(MarketplacePost marketplacePost);
        Task<MarketplacePost> GetMarketplacePostById(Guid id);
        Task<ActionResult<IEnumerable<MarketplacePost>>> GetMarketplacePosts();
        Task<EntityEntry> RemoveMarketplacePost(MarketplacePost marketplacePost);
    }
}