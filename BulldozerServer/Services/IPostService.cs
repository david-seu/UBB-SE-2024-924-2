namespace BulldozerServer.Services
{
    public interface IPostService
    {
        void AddPost(MarketplacePost marketplacePost);
        void ConfirmPost(Guid postID);
        void FavoritePost(Guid postID, Guid userID);
        MarketplacePost GetPostById(Guid id);
        List<MarketplacePost> GetPosts();
        void RemoveConfirmation(Guid postID);
        void RemovePost(MarketplacePost marketplacePost);
        void UnfavoritePost(Guid postID, Guid userID);
    }
}