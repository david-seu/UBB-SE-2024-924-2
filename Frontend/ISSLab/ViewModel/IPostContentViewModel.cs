using ISSLab.Model.Entities;

namespace ISSLab.ViewModel
{
    public interface IPostContentViewModel
    {
        string AvailableFor { get; }
        string BidButtonVisible { get; set; }
        string BidPrice { get; }
        string BidPriceVisible { get; set; }
        string BuyButtonVisible { get; set; }
        string Contact { get; set; }
        string Delivery { get; set; }
        string Description { get; set; }
        string DonationButtonVisible { get; set; }
        string Interests { get; }
        string Location { get; }
        string Media { get; }
        string Price { get; }
        string ProfilePicture { get; }
        MarketplacePost MarketplacePost { get; set; }
        string TimePosted { get; }
        string Uninterests { get; }
        string Username { get; }
        string Visible { get; set; }

        void AddInterests();
        void AddPostToCart();
        void AddPostToFavorites();
        void AddUninterests();
        void Donate();
        MarketplacePost GetPost();
        void HidePost();
        void SendBuyingMessage();
        void UpdateBidPrice();
    }
}