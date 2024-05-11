using ISSLab.Model.Entities;

namespace ISSLab.Model.Repositories
{
    public interface IPostRepository
    {
        void AddPost(MarketplacePost newMarketplacePost);
        List<MarketplacePost> GetAllPosts();
        MarketplacePost GetPostById(Guid id);
        void RemovePost(Guid id);
    }
}