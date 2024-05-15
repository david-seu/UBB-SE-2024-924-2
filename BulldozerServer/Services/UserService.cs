using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BulldozerServer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IPostRepository postRepository;

        public UserService(IUserRepository users, IPostRepository posts)
        {
            this.userRepository = users;
            this.postRepository = posts;
        }

        public void AddUser(UserMarketplace user)
        {
            userRepository.AddUser(user);
        }

        public void RemoveUser(UserMarketplace user)
        {
            userRepository.DeleteUser(user.Id);
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
            return userRepository.GetAll();
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
