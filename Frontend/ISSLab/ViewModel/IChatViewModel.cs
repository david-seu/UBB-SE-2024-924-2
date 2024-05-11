using System.Collections.ObjectModel;
using ISSLab.Model.Entities;

namespace ISSLab.ViewModel
{
    public interface IChatViewModel
    {
        ObservableCollection<Message> AllMessages { get; set; }
        MarketplacePost RefferedMarketplacePost { get; set; }
        UserMarketplace ChatUser { get; set; }

        void AddMessage(Message message);
        void SendBuyingMessage(string imagePath);
        void SendMessage(string message, bool isMine, bool isSellingPost);
    }
}