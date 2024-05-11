using ISSLab.Model.Entities;

namespace ISSLab.Services
{
    public interface IUserService
    {
        void AddPostToCart(Guid groupId, Guid postId, Guid userId);
        void AddPostToFavorites(Guid groupId, Guid postId, Guid userId);
        void AddUser(User user);
        List<MarketplacePost> GetFavoritePosts(Guid groupId, Guid userId);
        User GetUserById(Guid id);
        List<User> GetUsers();
        bool IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid groupId, Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId);
        void RemoveUser(User user);
        void UpdateUserUsername(Guid user, string username);
        List<MarketplacePost> GetPostsFromCart(Guid userId, Guid groupId);
    }
}