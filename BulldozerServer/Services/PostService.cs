using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public class PostService : IPostService
    {
        private DatabaseContext databaseContext;

        public PostService(DatabaseContext posts)
        {
            this.databaseContext = posts;
        }

        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetPosts()
        {
            return await databaseContext.MarketplacePost.ToListAsync();
        }

        public async Task<EntityEntry<MarketplacePost>> AddPost(MarketplacePost marketplacePost)
        {
            var context = databaseContext.MarketplacePost.Add(marketplacePost);
            await databaseContext.SaveChangesAsync();
            return context;
        }
        public async Task<EntityEntry> RemovePost(MarketplacePost marketplacePost)
        {
            var postToDelete = databaseContext.MarketplacePost.FindAsync(marketplacePost.MarketplacePostId);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
            var context = databaseContext.Remove(marketplacePost.MarketplacePostId);
            await databaseContext.SaveChangesAsync();
            return context;
        }
        public async Task<MarketplacePost> GetPostById(Guid id)
        {
            var context = await databaseContext.MarketplacePost.FindAsync(id);
            return context;
        }
    }
}
