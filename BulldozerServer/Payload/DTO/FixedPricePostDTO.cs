using BulldozerServer.Payloads.DTO;

namespace BulldozerServer.Payload.DTO
{
    public class FixedPricePostDTO : MarketplacePostDTO
    {
        private double price;
        private bool isNegotiable;
        private string deliveryType;

        public double Price { get => price; set => price = value; }
        public bool IsNegotiable { get => isNegotiable; set => isNegotiable = value; }
        public string DeliveryType { get => deliveryType; set => deliveryType = value; }
    }
}
