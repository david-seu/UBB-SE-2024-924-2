using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class FixedPriceMarketplacePost : MarketplacePost
    {
        private double price;
        private DateTime expirationDate;
        private string delivery;
        private Guid buyerId;

        public FixedPriceMarketplacePost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, double price, DateTime expirationDate, string delivery, Guid buyerId, string type, bool confirmed) : base(media, authorId, groupId, location, description, title, contacts, type, confirmed)
        {
            this.price = price;
            this.expirationDate = expirationDate;
            this.delivery = delivery;
            this.buyerId = buyerId;
        }

        public FixedPriceMarketplacePost() : base()
        {
            price = 0;
            expirationDate = DateTime.Now;
            delivery = Constants.EMPTY_STRING;
            buyerId = Guid.Empty;
        }

        public FixedPriceMarketplacePost(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, string media, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string location, string description, string title, List<InterestStatus> interestStatuses, string contacts, double price, DateTime expirationDate, string delivery, Guid buyerId, string type, bool confirmed, int views) : base(id, usersThatShared, usersThatLiked, media, creationDate, authorId, groupId, promoted, usersThatFavorited, location, description, title, interestStatuses, contacts, type, confirmed, views)
        {
            this.price = price;
            this.expirationDate = expirationDate;
            this.delivery = delivery;
            this.buyerId = buyerId;
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }
        public string Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }
        public Guid BuyerId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }

        public void BuyProduct(Guid buyerId)
        {
            if (this.buyerId != Guid.Empty)
            {
                throw new Exception("Product already bought");
            }
            this.buyerId = buyerId;
        }
    }
}
