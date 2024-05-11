using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;
using ISSLab.Services;

namespace ISSLab.Model.Repositories
{
    public class PostRepository : IPostRepository
    {
        private List<MarketplacePost> allPosts;

        public PostRepository()
        {
            this.allPosts = new List<MarketplacePost>();
        }

        public void AddPost(MarketplacePost newMarketplacePost)
        {
            allPosts.Add(newMarketplacePost);
        }

        public void RemovePost(Guid id)
        {
            for (int i = 0; i < allPosts.Count; i++)
            {
                if (allPosts[i].Id == id)
                {
                    allPosts.RemoveAt(i);
                    break;
                }
            }
        }

        public List<MarketplacePost> GetAllPosts()
        {
            return allPosts;
        }

        public MarketplacePost GetPostById(Guid postId)
        {
            for (int i = 0; i < allPosts.Count; i++)
            {
                if (allPosts[i].Id == postId)
                {
                    return allPosts[i];
                }
            }

            throw new Exception("MarketplacePost does not exist!");
        }
    }
}
