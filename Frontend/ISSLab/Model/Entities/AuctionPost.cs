using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class AuctionPost : FixedPricePost
    {
        private Guid currentPriceLeader;
        private double currentBidPrice;
        private double minimumBidPrice;
        private bool onGoing;

        public AuctionPost(string mediaContent, Guid authorId, Guid groupId, string itemLocation, string description, string title, string phoneNumber, double price, DateTime expirationDate, string deliveryType, Guid buyerId, Guid currentPriceLeader, double currentBidPrice, double minimumBidPrice, bool confirmed) : base(mediaContent, authorId, groupId, itemLocation, description, title, phoneNumber, price, expirationDate, deliveryType, buyerId, Constants.AUCTION_POST_TYPE, confirmed)
        {
            this.currentPriceLeader = Guid.Empty;
            this.currentBidPrice = currentBidPrice;
            this.minimumBidPrice = minimumBidPrice;
            onGoing = true;
        }

        public AuctionPost() : base()
        {
            Type = Constants.AUCTION_POST_TYPE;
            currentPriceLeader = Guid.Empty;
            currentBidPrice = 0;
            minimumBidPrice = 0;
        }

        public AuctionPost(Guid postId, List<Guid> usersThatShared, List<Guid> usersThatLiked, string mediaContent, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string itemLocation, string description, string title, List<InterestStatus> interestStatuses, string phoneNumber, double price, DateTime expirationDate, string deliveryType, Guid buyerId, Guid currentPriceLeader, double currentBidPrice, double minimumBidPrice, bool confirmed, int viewCount, bool onGoing) : base(postId, usersThatShared, usersThatLiked, mediaContent, creationDate, authorId, groupId, promoted, usersThatFavorited, itemLocation, description, title, interestStatuses, phoneNumber, price, expirationDate, deliveryType, buyerId, Constants.AUCTION_POST_TYPE, confirmed, viewCount)
        {
            this.currentPriceLeader = currentPriceLeader;
            this.currentBidPrice = currentBidPrice;
            this.minimumBidPrice = minimumBidPrice;
            this.onGoing = onGoing;
        }

        public bool OnGoing { get => onGoing; set => onGoing = value; }

        public double CurrentBidPrice { get => currentBidPrice; set => currentBidPrice = value; }

        public double MinimumBidPrice { get => minimumBidPrice; set => minimumBidPrice = value; }

        public Guid CurrentPriceLeader { get => currentPriceLeader; set => currentPriceLeader = value; }

        public void PlaceBid(Guid userId, double bidPrice)
        {
            if (bidPrice <= minimumBidPrice)
            {
                throw new Exception("Bid price is lower than minimum bid price");
            }
            if (bidPrice > currentBidPrice)
            {
                currentBidPrice = bidPrice;
                currentPriceLeader = userId;
                SlightlyPostponeExpirationDate();
            }
        }

        public void SlightlyPostponeExpirationDate()
        {
            DateTime now = DateTime.Now;
            ExpirationDate = ExpirationDate.AddSeconds(Constants.EXPIRATION_DATE_SLIGHT_PROLONGMENT_THRESHOLD_IN_SECONDS);
        }
    }
}
