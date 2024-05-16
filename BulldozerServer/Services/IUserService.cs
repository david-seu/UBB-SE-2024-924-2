using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public interface IUserService
    {
        void AddPostToCart(Guid groupId, Guid postId, Guid userId);
        void AddPostToFavorites(Guid groupId, Guid postId, Guid userId);
        Task<EntityEntry<User>> AddUser(User user);
        Task<List<MarketplacePost>> GetFavoritePosts(Guid groupId, Guid userId);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetUsers();
        Task<bool> IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid groupId, Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId); 
        void RemoveUser(User user);
        Task<User> UpdateUserUsername(Guid user, string username);
        Task<List<MarketplacePost>> GetPostsFromCart(Guid userId, Guid groupId);
    }
}