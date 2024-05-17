using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Mapper;
using BulldozerServer.Payloads.DTO;
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

        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetMarketplacePosts()
        {
            return await databaseContext.MarketplacePosts.ToListAsync();
        }

        public MarketplacePostDTO AddMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            var marketplacePost = MarketplacePostMapper.MapMarketplacePostDTOToMarketplacePost(marketplacePostDTO);
            var context = databaseContext.MarketplacePosts.Add(marketplacePost);
            databaseContext.SaveChanges();
            return MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(context.Entity);
        }
        public async Task<EntityEntry> RemoveMarketplacePost(MarketplacePostDTO marketplacePostDTO)
        {
            var marketplacePost = MarketplacePostMapper.MapMarketplacePostDTOToMarketplacePost(marketplacePostDTO);
            var postToDelete = await databaseContext.MarketplacePosts.FindAsync(marketplacePost.MarketplacePostId);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
            var context = databaseContext.Remove(marketplacePost.MarketplacePostId);
            await databaseContext.SaveChangesAsync();
            return context;
        }
        public async Task<MarketplacePost> GetMarketplacePostById(Guid id)
        {
            var postToDelete = await databaseContext.MarketplacePosts.FindAsync(id);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
            return postToDelete;
        }
    }
}
