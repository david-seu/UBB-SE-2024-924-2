using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model;
using ISSLab.Model.Entities;
using Moq;

namespace Tests.Model
{
    internal class DonationMarketplacePostTests
    {
        private DonationMarketplacePost donationMarketplacePostSimpleConstructor;
        private DonationMarketplacePost donationMarketplacePost;
        private Guid id;
        private List<Guid> usersThatShared;
        private List<Guid> usersThatLiked;
        private string media;
        private DateTime creationDate;
        private Guid authorId;
        private Guid groupId;
        private bool promoted;
        private List<Guid> usersThatFavorited;
        private string location;
        private string description;
        private string title;
        private List<InterestStatus> interestStatuses;
        private string contacts;
        private double currentDonationAmount;
        private string donationPageLink;
        private string type;
        private bool confirmed;
        private int views;

        [SetUp]
        public void SetUp()
        {
            donationMarketplacePost = new DonationMarketplacePost();
            donationMarketplacePostSimpleConstructor = new DonationMarketplacePost(id, usersThatShared, usersThatLiked, media, creationDate, authorId, groupId, promoted, usersThatFavorited, location, description, title, interestStatuses, contacts, currentDonationAmount, donationPageLink, type, confirmed, views);
            id = Guid.NewGuid();
            usersThatShared = new List<Guid>();
            usersThatLiked = new List<Guid>();
            media = " ";
            creationDate = new DateTime();
            authorId = Guid.NewGuid();
            groupId = Guid.NewGuid();
            promoted = true;
            usersThatFavorited = new List<Guid>();
            location = " ";
            description = " ";
            title = " ";
            interestStatuses = new List<InterestStatus>();
            contacts = " ";
            currentDonationAmount = 0f;
            donationPageLink = " ";
            type = " ";
            confirmed = true;
            views = 0;
        }

        [Test]
        public void DonationAmount_AnyDonationPost_ReturnsDonationAmount()
        {
            donationMarketplacePost.DonationAmount = 10.6f;

            Assert.That(donationMarketplacePost.DonationAmount, Is.EqualTo(10.6f));
        }

        [Test]
        public void DonationPageLink_AnyDonationPost_ReturnsDonationPageLink()
        {
            donationMarketplacePost.DonationPageLink = "/1";

            Assert.That(donationMarketplacePost.DonationPageLink, Is.EqualTo("/1"));
        }
    }
}
