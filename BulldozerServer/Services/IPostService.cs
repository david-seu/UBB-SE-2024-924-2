using BulldozerServer.Domain.MarketplacePosts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public interface IPostService
    {
        Task<EntityEntry<MarketplacePost>> AddPost(MarketplacePost marketplacePost);
        Task<MarketplacePost> GetPostById(Guid id);
        Task<ActionResult<IEnumerable<MarketplacePost>>> GetPosts();
        Task<EntityEntry> RemovePost(MarketplacePost marketplacePost);
    }
}