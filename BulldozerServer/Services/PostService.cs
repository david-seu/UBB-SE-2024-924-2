using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Controllers;
using ISSLab.Model;
using ISSLab.Model.Entities;
using ISSLab.Model.Repositories;
namespace ISSLab.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;

        public PostService(IPostRepository posts)
        {
            this.postRepository = posts;
        }

        public List<MarketplacePost> GetPosts()
        {
            return postRepository.GetAllPosts();
        }

        public void AddPost(MarketplacePost marketplacePost)
        {
            postRepository.AddPost(marketplacePost);
        }
        public void RemovePost(MarketplacePost marketplacePost)
        {
            postRepository.RemovePost(marketplacePost.Id);
        }
        public MarketplacePost GetPostById(Guid id)
        {
            MarketplacePost? postWithThatId = postRepository.GetPostById(id);
            if (postWithThatId == null)
            {
                throw new Exception("MarketplacePost not found");
            }
            return postWithThatId;
        }

        public void RemoveConfirmation(Guid postID)
        {
            MarketplacePost? post = postRepository.GetPostById(postID);
            if (post == null)
            {
                throw new Exception("MarketplacePost not found");
            }
            post.Confirmed = false;
        }

        public void ConfirmPost(Guid postID)
        {
            MarketplacePost? post = postRepository.GetPostById(postID);
            if (post == null)
            {
                throw new Exception("MarketplacePost not found");
            }
            post.Confirmed = true;
        }

        public void FavoritePost(Guid postId, Guid userId)
        {
            MarketplacePost? post = postRepository.GetPostById(postId);
            if (post == null)
            {
                throw new Exception("MarketplacePost not found");
            }
            post.UsersThatFavorited.Add(userId);
        }

        public void UnfavoritePost(Guid postId, Guid userId)
        {
            MarketplacePost? post = postRepository.GetPostById(postId);
            if (post == null)
            {
                throw new Exception("MarketplacePost not found");
            }
            post.UsersThatFavorited.Remove(userId);
        }
    }
}
