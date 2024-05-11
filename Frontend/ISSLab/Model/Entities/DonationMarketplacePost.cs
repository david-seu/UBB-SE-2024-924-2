using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ISSLab.Model.Entities
{
    public class DonationMarketplacePost : MarketplacePost
    {
        private double currentDonationAmount;
        private string donationPageLink;

        public DonationMarketplacePost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, string donationPageLink, string type, bool confirmed) : base(media, authorId, groupId, location, description, title, contacts, type, confirmed)
        {
            currentDonationAmount = 0;
            this.donationPageLink = donationPageLink;
        }

        public DonationMarketplacePost() : base()
        {
            currentDonationAmount = 0;
            donationPageLink = Constants.EMPTY_STRING;
        }

        public DonationMarketplacePost(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, string media, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string location, string description, string title, List<InterestStatus> interestStatuses, string contacts, double currentDonationAmount, string donationPageLink, string type, bool confirmed, int views) : base(id, usersThatShared, usersThatLiked, media, creationDate, authorId, groupId, promoted, usersThatFavorited, location, description, title, interestStatuses, contacts, type, confirmed, views)
        {
            this.currentDonationAmount = currentDonationAmount;
            this.donationPageLink = donationPageLink;
        }

        public double DonationAmount
        {
            get { return currentDonationAmount; }
            set { currentDonationAmount = value; }
        }

        public string DonationPageLink
        {
            get { return donationPageLink; }
            set { donationPageLink = value; }
        }
    }
}
