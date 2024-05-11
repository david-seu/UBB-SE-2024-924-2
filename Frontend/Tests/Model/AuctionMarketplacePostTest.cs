using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace Tests.Model
{
    internal class AuctionMarketplacePostTest
    {
        private AuctionMarketplacePost marketplacePostEmpty;
        private AuctionMarketplacePost marketplacePostWithId;
        private AuctionMarketplacePost marketplacePostWithoutId;

        private Guid currentPriceLeader;
        private double currentBidPrice;
        private double minimumBidPrice;
        private bool onGoing;

        [SetUp]
        public void SetUp()
        {
            currentPriceLeader = Guid.NewGuid();
            currentBidPrice = 200;
            minimumBidPrice = 100;
            onGoing = true;

            marketplacePostEmpty = new AuctionMarketplacePost();
            marketplacePostWithId = new AuctionMarketplacePost(Guid.NewGuid(), new List<Guid>(), new List<Guid>(), string.Empty, DateTime.Now, Guid.NewGuid(), Guid.NewGuid(), true, new List<Guid>(), string.Empty, string.Empty, string.Empty, new List<InterestStatus>(), string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), currentPriceLeader, currentBidPrice, minimumBidPrice, false, 100, onGoing);
            marketplacePostWithoutId = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, 100, DateTime.Now, string.Empty, Guid.NewGuid(), currentPriceLeader, currentBidPrice, minimumBidPrice, true);
        }

        [Test]
        public void OnGoingGet_FromPostInstantiatedWithoutId_ShouldBeTrue()
        {
            Assert.That(marketplacePostWithoutId.OnGoing, Is.True);
        }

        [Test]
        public void OnGoingSet_ForPostEmpty_OnGoingBecomesNewValue()
        {
            bool newOnGoing = true;
            marketplacePostEmpty.OnGoing = newOnGoing;
            Assert.That(marketplacePostEmpty.OnGoing, Is.EqualTo(newOnGoing));
        }

        [Test]
        public void OnGoingSet_ForPostWithoutId_OnGoingBecomesNewValue()
        {
            bool newOnGoing = false;
            marketplacePostWithoutId.OnGoing = newOnGoing;
            Assert.That(marketplacePostWithoutId.OnGoing, Is.EqualTo(newOnGoing));
        }

        [Test]
        public void OnGoingSet_ForPostWithId_OnGoingBecomesNewValue()
        {
            bool newOnGoing = false;
            marketplacePostWithId.OnGoing = newOnGoing;
            Assert.That(marketplacePostWithId.OnGoing, Is.EqualTo(newOnGoing));
        }

        [Test]
        public void CurrentBidPrice_ForPostEmpty_ShouldBeZero()
        {
            Assert.That(marketplacePostEmpty.CurrentBidPrice, Is.EqualTo(0));
        }

        [Test]
        public void CurrentBidPrice_ForPostWithId_ShouldBeEqualToCurrentBidPrice()
        {
            Assert.That(marketplacePostWithId.CurrentBidPrice, Is.EqualTo(currentBidPrice));
        }

        [Test]
        public void CurrentBidPrice_ForPostWithoutId_ShouldBeEqualToCurrentBidPrice()
        {
            Assert.That(marketplacePostWithId.CurrentBidPrice, Is.EqualTo(currentBidPrice));
        }

        [Test]
        public void CurrentBidPrice_ChangeForPostEmpty_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostEmpty.CurrentBidPrice = newValue;
            Assert.That(marketplacePostEmpty.CurrentBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void CurrentBidPrice_ChangeForPostWithId_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostWithId.CurrentBidPrice = newValue;
            Assert.That(marketplacePostWithId.CurrentBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void CurrentBidPrice_ChangeForPostWithoutId_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostWithoutId.CurrentBidPrice = newValue;
            Assert.That(marketplacePostWithoutId.CurrentBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void MinimumBidPrice_ChangeForPostEmpty_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostEmpty.MinimumBidPrice = newValue;
            Assert.That(marketplacePostEmpty.MinimumBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void MinimumBidPrice_ChangeForPostWithId_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostWithId.MinimumBidPrice = newValue;
            Assert.That(marketplacePostWithId.MinimumBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void MinimumBidPrice_ChangeForPostWithoutId_ShouldBeEqualToNewValue()
        {
            double newValue = 140;
            marketplacePostWithoutId.MinimumBidPrice = newValue;
            Assert.That(marketplacePostWithoutId.MinimumBidPrice, Is.EqualTo(newValue));
        }

        [Test]
        public void MinimumBidPrice_ForPostEmpty_ShouldBeZero()
        {
            Assert.That(marketplacePostEmpty.MinimumBidPrice, Is.EqualTo(0));
        }
        [Test]
        public void MinimumBidPrice_ForPostWithId_ShouldBeEqualToMinimumBidPrice()
        {
            Assert.That(minimumBidPrice, Is.EqualTo(marketplacePostWithId.MinimumBidPrice));
        }

        [Test]
        public void MinimumBidPrice_ForPostWithoutId_ShouldBeEqualToMinimumBidPrice()
        {
            Assert.That(minimumBidPrice, Is.EqualTo(marketplacePostWithoutId.MinimumBidPrice));
        }

        [Test]
        public void CurrentPriceLeader_ForPostEmpty_ShouldBeEmpty()
        {
            Assert.That(marketplacePostEmpty.CurrentPriceLeader, Is.EqualTo(Guid.Empty));
        }
        [Test]
        public void CurrentPriceLeader_ForPostWithoutId_ShouldBeEmpty()
        {
            Assert.That(marketplacePostWithoutId.CurrentPriceLeader, Is.EqualTo(Guid.Empty));
        }
        [Test]
        public void CurrentPriceLeader_ForPostWithId_ShouldBeEqualToCurrentPriceLeader()
        {
            Assert.That(marketplacePostWithId.CurrentPriceLeader, Is.EqualTo(currentPriceLeader));
        }

        [Test]
        public void CurrentPriceLeader_ChangePriceLeaderForPostEmpty_ShouldBeEqualToNewValue()
        {
            Guid newValue = Guid.NewGuid();
            marketplacePostEmpty.CurrentPriceLeader = newValue;
            Assert.That(marketplacePostEmpty.CurrentPriceLeader, Is.EqualTo(newValue));
        }

        [Test]
        public void CurrentPriceLeader_ChangePriceLeaderForPostWithoutId_ShouldBeEqualToNewValue()
        {
            Guid newValue = Guid.NewGuid();
            marketplacePostWithoutId.CurrentPriceLeader = newValue;
            Assert.That(marketplacePostWithoutId.CurrentPriceLeader, Is.EqualTo(newValue));
        }

        [Test]
        public void CurrentPriceLeader_ChangePriceLeaderForPostWithId_ShouldBeEqualToNewValue()
        {
            Guid newValue = Guid.NewGuid();
            marketplacePostWithId.CurrentPriceLeader = newValue;
            Assert.That(marketplacePostWithId.CurrentPriceLeader, Is.EqualTo(newValue));
        }

        [Test]
        public void Type_ForPostEmpty_ShouldBeAuction()
        {
            Assert.That(marketplacePostEmpty.Type, Is.EqualTo(Constants.AUCTION_POST_TYPE));
        }

        [Test]
        public void Type_ForPostWithoutId_ShouldBeAuction()
        {
            Assert.That(marketplacePostWithoutId.Type, Is.EqualTo(Constants.AUCTION_POST_TYPE));
        }

        [Test]
        public void Type_ForPostWithId_ShouldBeAuction()
        {
            Assert.That(marketplacePostWithId.Type, Is.EqualTo(Constants.AUCTION_POST_TYPE));
        }

        [Test]
        public void Add30SecondsToExpirationDate_ForAnyPost_ShouldAdd30Seconds()
        {
            DateTime expectedExpirationDate = DateTime.Now.AddSeconds(30);

            marketplacePostEmpty.SlightlyPostponeExpirationDate();
            DateTime actualExpirationDate = marketplacePostEmpty.ExpirationDate;
            TimeSpan difference = actualExpirationDate - expectedExpirationDate;
            Assert.Less(difference.TotalSeconds, 1);
        }

        [Test]
        public void PlaceBid_ForAnyPostBidSmallerThanMinimum_ShouldThrowException()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { marketplacePostEmpty.PlaceBid(Guid.NewGuid(), -1000); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("Bid price is lower than minimum bid price"));
        }

        [Test]
        public void PlaceBid_ForAnyPostBidIsHigherThanMinimumButLowerThanCurrent_CurrentBidPriceShouldRemainTheSame()
        {
            double initialPrice = marketplacePostWithoutId.CurrentBidPrice;
            marketplacePostWithoutId.PlaceBid(Guid.NewGuid(), 150);
            Assert.That(marketplacePostWithoutId.CurrentBidPrice, Is.EqualTo(initialPrice));
        }

        [Test]
        public void PlaceBid_ForAnyPostBidIsHigherThanCurrentPrice_CurrentBidPriceChangesToNewValue()
        {
            marketplacePostWithoutId.PlaceBid(new Guid(), 900);
            Assert.That(marketplacePostWithoutId.CurrentBidPrice, Is.EqualTo(900));
        }
        [Test]
        public void PlaceBid_ForAnyPostBidIsHigherThanCurrentPrice_PriceLeaderChangesToNewValue()
        {
            Guid newPriceLeader = Guid.NewGuid();
            marketplacePostWithoutId.PlaceBid(newPriceLeader, 900);
            Assert.That(marketplacePostWithoutId.CurrentPriceLeader, Is.EqualTo(newPriceLeader));
        }

        [Test]
        public void PlaceBid_ForAnyPostBidIsHigherThanCurrentPrice_ExpirationDateIsExtended()
        {
            Guid newPriceLeader = Guid.NewGuid();

            DateTime expectedExpirationDate = DateTime.Now.AddSeconds(30);

            marketplacePostWithoutId.PlaceBid(newPriceLeader, 900);
            DateTime actualExpirationDate = marketplacePostEmpty.ExpirationDate;
            TimeSpan difference = actualExpirationDate - expectedExpirationDate;
            Assert.Less(difference.TotalSeconds, 1);
        }
    }
}
