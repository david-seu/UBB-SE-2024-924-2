using ISSLab.Domain;
using ISSLab.Domain.MarketplacePosts;

namespace ISSLab.Services
{
    public interface IApiService
    {
        Task<Uri> AddMarketplacePostAsync(MarketplacePost post);
        Task<Uri> AddPostToCart(Guid postId, Guid userId);
        Task<Uri> AddPostToFavorite(Guid postId, Guid userId);
        void Dispose();
        Task<List<MarketplacePost>> GetFavouritePosts(Guid userId);
        Task<List<User>> GetGroupMembers(Guid groupId);
        Task<List<Poll>> GetGroupPolls(Guid groupId);
        Task<List<GroupPost>> GetGroupPosts(Guid groupId);
        Task<List<Group>> GetGroupsAsync();
        Task<List<MarketplacePost>> GetMarketplacePosts();
        Task<List<Post>> GetPosts();
        Task<List<MarketplacePost>> GetPostsFromCart(Guid userId);
        Task<List<Request>> GetRequestsToJoinGroup(Guid groupId);
        Task<User> GetUserById(Guid userId);
    }
}