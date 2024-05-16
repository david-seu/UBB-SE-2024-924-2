using System.Collections.ObjectModel;
using ISSLab.Domain.MarketplacePosts;

namespace ISSLab.ViewModel
{
    public interface IMainWindowViewModel
    {
        ICreatePostViewModel PostCreationViewModel { get; set; }
        ObservableCollection<IPostContentViewModel> ShownPosts { get; set; }

        Guid IdOfActiveUser { get; set; }

        void ChangeToCart();
        void ChangeToFavorites();
        void ChangeToMarketPlace();
        void LoadPostsCommand(List<MarketplacePost> postsToLoad);
    }
}