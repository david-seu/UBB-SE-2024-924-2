namespace ISSLab.Domain.MarketplacePosts
{
    public class FixedPricePost : MarketplacePost
    {
        private double price;
        private bool isNegotiable;
        private string deliveryType;

        public double Price { get => price; set => price = value; }
        public bool IsNegotiable { get => isNegotiable; set => isNegotiable = value; }
        public string DeliveryType { get => deliveryType; set => deliveryType = value; }

        public FixedPricePost(Guid marketplacePostId, Guid authorId, Guid groupId, string title, string description, string mediaContent, string location,
            DateTime creationDate, DateTime? endDate, bool isPromoted, bool isActive, double price, bool isNegotiable, string deliveryType)
            : base(marketplacePostId, authorId, groupId, title, description, mediaContent, location, creationDate, endDate, isPromoted, isActive)
        {
            this.price = price;
            this.isNegotiable = isNegotiable;
            this.deliveryType = deliveryType;
        }

        public FixedPricePost() : base()
        {
            this.price = 0;
            this.isNegotiable = false;
            this.deliveryType = Constants.EMPTY_STRING;
        }
    }
}
