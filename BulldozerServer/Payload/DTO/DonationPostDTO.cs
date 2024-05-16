using BulldozerServer.Payloads.DTO;

namespace BulldozerServer.Payload.DTO
{
    public class DonationPostDTO : MarketplacePostDTO
    {
        private string donationLink;
        private double currentDonationAmount;

        public string DonationLink { get => donationLink; set => donationLink = value; }
        public double CurrentDonationAmount { get => currentDonationAmount; set => currentDonationAmount = value; }
    }
}
