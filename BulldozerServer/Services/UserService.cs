using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BulldozerServer.Controllers;
using BulldozerServer.Domain;
using ISSLab.Model.Entities;
using ISSLab.Model.Repositories;
using Microsoft.EntityFrameworkCore;
namespace ISSLab.Services
{
    public class UserService : IUserService
    {
        
        private DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async void AddUser(UserMarketplace user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return -1;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return 0;
        }

        public UserMarketplace GetUserById(Guid id)
        {
            UserMarketplace? user = userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public List<UserMarketplace> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public bool IsUserInGroup(Guid userId, Guid groupId)
        {
            UserMarketplace user = GetUserById(userId);
            return user.Groups.Contains(groupId);
        }

        public void UpdateUserUsername(Guid user, string username)
        {
            userRepository.UpdateUserUsername(user, username);
        }

        public void AddPostToCart(Guid groupId, Guid postId, Guid userId)
        {
            userRepository.AddPostToCart(groupId, userId, postId);
        }

        public void RemovePostFromCart(Guid groupId, Guid postId, Guid userId)
        {
            userRepository.RemoveFromCart(groupId, userId, postId);
        }

        public void AddPostToFavorites(Guid groupId, Guid postId, Guid userId)
        {
            userRepository.AddToFavorites(groupId, userId, postId);
        }

        public void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId)
        {
            userRepository.RemoveFromFavorites(groupId, userId, postId);
        }

        public List<MarketplacePost> GetFavoritePosts(Guid groupId, Guid userId)
        {
            List<MarketplacePost> favoritePosts = new List<MarketplacePost>();
            UsersFavoritePosts favorites = userRepository.GetById(userId).Favorites.Find(checkedFavorite => checkedFavorite.GroupId == groupId);
            if (favorites == null)
            {
                userRepository.GetById(userId).Favorites.Add(new UsersFavoritePosts(userId, groupId));
                return new List<MarketplacePost>();
            }
            foreach (Guid postId in favorites.Posts)
            {
                favoritePosts.Add(postRepository.GetPostById(postId));
            }
            return favoritePosts;
        }

        public List<MarketplacePost> GetPostsFromCart(Guid userId, Guid groupId)
        {
            Cart cart = userRepository.GetById(userId).Carts.Find(checkedCart => checkedCart.GroupId == groupId);
            List<MarketplacePost> cartedPosts = new List<MarketplacePost>();
            if (cart == null)
            {
                userRepository.GetById(userId).Carts.Add(new Cart(groupId, userId));
                return new List<MarketplacePost>();
            }
            foreach (Guid postId in cart.PostsSavedInCart)
            {
                cartedPosts.Add(postRepository.GetPostById(postId));
            }
            return cartedPosts;
        }
    }
}
