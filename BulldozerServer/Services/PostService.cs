﻿using System;
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

        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetMarketplacePosts()
        {
            return await databaseContext.MarketplacePost.ToListAsync();
        }

        public async Task<EntityEntry<MarketplacePost>> AddMarketplacePost(MarketplacePost marketplacePost)
        {
            var context = databaseContext.MarketplacePost.Add(marketplacePost);
            await databaseContext.SaveChangesAsync();
            return context;
        }
        public async Task<EntityEntry> RemoveMarketplacePost(MarketplacePost marketplacePost)
        {
            var postToDelete = await databaseContext.MarketplacePost.FindAsync(marketplacePost.MarketplacePostId);
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
            var postToDelete = await databaseContext.MarketplacePost.FindAsync(id);
            if (postToDelete == null)
            {
                throw new Exception("Post doesn't exist!");
            }
            return postToDelete;
        }
    }
}