using System.Collections.ObjectModel;
using ISSLab.Domain.MarketplacePosts;
using ISSLab.Model.Entities;

namespace ISSLab.ViewModel
{
    public interface IMainWindowViewModel
    {
        ICreatePostViewModel PostCreationViewModel { get; set; }
        ObservableCollection<IPostContentViewModel> ShownPosts { get; set; }

        void ChangeToCart();
        void ChangeToFavorites();
        void ChangeToMarketPlace();
        void LoadPostsCommand(List<MarketplacePost> postsToLoad);
    }
}