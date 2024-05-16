namespace BulldozerServer.Payload.DTO
{
    public class AuctionPostDTO : FixedPricePostDTO
    {
        private Guid currentPriceLeader;
        private double currentBidPrice;
        private double minimumBidPrice;

        public Guid CurrentPriceLeader { get => currentPriceLeader; set => currentPriceLeader = value; }
        public double CurrentBidPrice { get => currentBidPrice; set => currentBidPrice = value; }
        public double MinimumBidPrice { get => minimumBidPrice; set => minimumBidPrice = value; }
    }
}
