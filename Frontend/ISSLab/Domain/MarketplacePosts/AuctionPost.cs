namespace ISSLab.Domain.MarketplacePosts
{
    public class AuctionPost : MarketplacePost
    {
        private Guid currentPriceLeader;
        private double currentBidPrice;
        private double minimumBidPrice;

        public Guid CurrentPriceLeader { get => currentPriceLeader; set => currentPriceLeader = value; }
        public double CurrentBidPrice { get => currentBidPrice; set => currentBidPrice = value; }
        public double MinimumBidPrice { get => minimumBidPrice; set => minimumBidPrice = value; }

        public AuctionPost(Guid marketplacePostId, Guid authorId, Guid groupId, string title, string description, string mediaContent, string location,
                               DateTime creationDate, DateTime? endDate, bool isPromoted, bool isActive, Guid currentPriceLeader, double currentBidPrice,
                               double minimumBidPrice)
            : base(marketplacePostId, authorId, groupId, title, description, mediaContent, location, creationDate, endDate, isPromoted, isActive)
        {
            this.currentPriceLeader = currentPriceLeader;
            this.currentBidPrice = currentBidPrice;
            this.minimumBidPrice = minimumBidPrice;
        }

        public AuctionPost() : base()
        {
            this.currentPriceLeader = Guid.NewGuid();
            this.currentBidPrice = 0;
            this.minimumBidPrice = 0;
        }
    }
}
