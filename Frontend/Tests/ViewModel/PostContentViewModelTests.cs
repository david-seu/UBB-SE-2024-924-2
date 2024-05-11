using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using ISSLab.Services;
using ISSLab.View;
using ISSLab.ViewModel;
using Moq;
using ISSLab.Model.Entities;

namespace Tests.ViewModel
{
    public class PostContentViewModelTests
    {
        private FakeUserService fakeUserService;
        private PostContentViewModel postViewModel;
        private string donationButtonVisible;
        private MarketplacePost ourMarketplacePost;

        [SetUp]
        public void SetUp()
        {
            fakeUserService = new FakeUserService();
            ourMarketplacePost = new MarketplacePost();
            ourMarketplacePost.Type = Constants.DONATION_POST_TYPE;
            postViewModel = new PostContentViewModel(ourMarketplacePost, new User(), Guid.NewGuid(), Guid.NewGuid(), fakeUserService, new FakeChatFactory());
            Assert.That(postViewModel.DonationButtonVisible, Is.EqualTo(Constants.VISIBLE_VISIBILITY));
            ourMarketplacePost = new MarketplacePost();
            ourMarketplacePost.Type = Constants.FIXED_PRICE_POST_TYPE;
            postViewModel = new PostContentViewModel(ourMarketplacePost, new User(), Guid.NewGuid(), Guid.NewGuid(), fakeUserService, new FakeChatFactory());
            ourMarketplacePost = new MarketplacePost();
            ourMarketplacePost.Type = Constants.AUCTION_POST_TYPE;
            postViewModel = new PostContentViewModel(ourMarketplacePost, new User(), Guid.NewGuid(), Guid.NewGuid(), fakeUserService, new FakeChatFactory());
            postViewModel = new PostContentViewModel(new MarketplacePost(), new User(), Guid.NewGuid(), Guid.NewGuid(), fakeUserService, new FakeChatFactory());
        }

        [Test]
        public void DisplayRemainingTime_ForSeconds_ReturnsCorrectString()
        {
            TimeSpan timeLeft = TimeSpan.FromSeconds(30);

            string expectedResult = "Available for: 30 seconds";
            string actualResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DisplayRemainingTime_ForMinutes_ReturnsCorrectString()
        {
            TimeSpan timeLeft = TimeSpan.FromMinutes(30);

            string expectedResult = "Available for: 30 minutes";
            string actualResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DisplayRemainingTime_ForHours_ReturnsCorrectString()
        {
            TimeSpan timeLeft = TimeSpan.FromHours(3);

            string expectedResult = "Available for: 3 hours";
            string actualResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DisplayRemainingTime_ForDays_ReturnsCorrectString()
        {
            TimeSpan timeLeft = TimeSpan.FromDays(30);

            string expectedResult = "Available for: 30 days";
            string actualResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AvailableFor_ForFixedPricePost_ReturnsCorrectString()
        {
            DateTime expirationDate = DateTime.Now.AddDays(10);
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, 0, expirationDate, string.Empty, Guid.NewGuid(), Constants.FIXED_PRICE_POST_TYPE, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            TimeSpan timeLeft = expirationDate - DateTime.Now;
            string expectedResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(postViewModel.AvailableFor, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AvailableFor_ForAuctionPost_ReturnsCorrectString()
        {
            DateTime expirationDate = DateTime.Now.AddDays(10);
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, expirationDate, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            TimeSpan timeLeft = expirationDate - DateTime.Now;
            string expectedResult = postViewModel.DisplayRemainingTime(timeLeft);

            Assert.That(postViewModel.AvailableFor, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AvailableFor_ForUnknownPostType_ReturnsEmptyString()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            string expectedResult = Constants.EMPTY_STRING;

            Assert.That(postViewModel.AvailableFor, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Visible_GetDefaultValue_ReturnsCorrectValue()
        {
            string expectedResult = Constants.VISIBLE_VISIBILITY;
            Assert.That(postViewModel.Visible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Visible_SetValue_SetsCorrectValue()
        {
            string expectedResult = "Invisible";
            postViewModel.Visible = expectedResult;
            Assert.That(postViewModel.Visible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Description_ForFixedPricePost_ReturnsCorrectValue()
        {
            string expectedDescription = "expected description";
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                expectedDescription, string.Empty, string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), string.Empty, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }
        [Test]
        public void Description_ForAuctionPost_ReturnsCorrectValue()
        {
            string expectedDescription = "expected description";
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, expectedDescription, string.Empty,
                string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }
        [Test]
        public void Description_ForUnknownPostType_ReturnsCorrectValue()
        {
            string expectedDescription = "expected description";
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, expectedDescription, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void Description_ForFixedPricePost_SetsCorrectValue()
        {
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), string.Empty, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            string expectedDescription = "expected description";
            postViewModel.Description = expectedDescription;
            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }
        [Test]
        public void Description_ForAuctionPost_SetsCorrectValue()
        {
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, DateTime.Now, string.Empty,  Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            string expectedDescription = "expected description";
            postViewModel.Description = expectedDescription;
            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }
        [Test]
        public void Description_ForUnknownPostType_SetsCorrectValue()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            string expectedDescription = "expected description";
            postViewModel.Description = expectedDescription;
            Assert.That(postViewModel.Description, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void Contact_ForFixedPricePost_ReturnsCorrectValue()
        {
            string expectedContacts = "expected contacts";
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, expectedContacts, 0, DateTime.Now, string.Empty, Guid.NewGuid(), string.Empty, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }
        [Test]
        public void Contact_ForAuctionPost_ReturnsCorrectValue()
        {
            string expectedContacts = "expected contacts";
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                expectedContacts, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }
        [Test]
        public void Contact_ForUnknownPostType_ReturnsCorrectValue()
        {
            string expectedContacts = "expected contacts";
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, expectedContacts, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }

        [Test]
        public void Contact_ForFixedPricePost_SetsCorrectValue()
        {
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), string.Empty, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            string expectedContacts = "expected contacts";
            postViewModel.Contact = expectedContacts;
            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }
        [Test]
        public void Contact_ForAuctionPost_SetsCorrectValue()
        {
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty,
                string.Empty, string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            string expectedContacts = "expected contacts";
            postViewModel.Contact = expectedContacts;
            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }
        [Test]
        public void Contact_ForUnknownPostType_SetsCorrectValue()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            string expectedContacts = "expected contacts";
            postViewModel.Contact = expectedContacts;
            Assert.That(postViewModel.Contact, Is.EqualTo(expectedContacts));
        }

        [Test]
        public void Delivery_ForFixedPricePost_ReturnsCorrectValue()
        {
            string expectedDelivery = "expected delivery";
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, 0, DateTime.Now, expectedDelivery, Guid.NewGuid(), Constants.FIXED_PRICE_POST_TYPE, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }
        [Test]
        public void Delivery_ForAuctionPost_ReturnsCorrectValue()
        {
            string expectedDelivery = "expected delivery";
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, DateTime.Now, expectedDelivery, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }
        [Test]
        public void Delivery_ForDonationOrUnknownPostType_ReturnsEmptyString()
        {
            string expectedDelivery = Constants.EMPTY_STRING;
            MarketplacePost donationMarketplacePost = new DonationMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Constants.DONATION_POST_TYPE, true);
            postViewModel.MarketplacePost = donationMarketplacePost;

            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));

            expectedDelivery = Constants.EMPTY_STRING;
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }

        [Test]
        public void Delivery_ForFixedPricePost_SetsCorrectValue()
        {
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Constants.FIXED_PRICE_POST_TYPE, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            string expectedDelivery = "expected delivery";
            postViewModel.Delivery = expectedDelivery;
            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }
        [Test]
        public void Delivery_ForAuctionPost_SetsCorrectValue()
        {
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            string expectedDelivery = "expected delivery";
            postViewModel.Delivery = expectedDelivery;
            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }
        [Test]
        public void Delivery_ForDonationOrUnknownPost_ReturnsEmptyString()
        {
            MarketplacePost donationMarketplacePost = new DonationMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Constants.DONATION_POST_TYPE, true);
            postViewModel.MarketplacePost = donationMarketplacePost;

            string expectedDelivery = Constants.EMPTY_STRING;
            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));

            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Delivery, Is.EqualTo(expectedDelivery));
        }

        [Test]
        public void DonationButtonVisible_GetDefaultValue_ReturnsCorrectValue()
        {
            string expectedResult = Constants.COLLAPSED_VISIBILITY;
            Assert.That(postViewModel.DonationButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DonationButtonVisible_SetValue_SetsCorrectValue()
        {
            string expectedResult = Constants.VISIBLE_VISIBILITY;
            postViewModel.DonationButtonVisible = expectedResult;
            Assert.That(postViewModel.DonationButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BuyButtonVisible_GetDefaultValue_ReturnsCorrectValue()
        {
            string expectedResult = Constants.COLLAPSED_VISIBILITY;
            Assert.That(postViewModel.BuyButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BuyButtonVisible_SetValue_SetsCorrectValue()
        {
            string expectedResult = Constants.VISIBLE_VISIBILITY;
            postViewModel.BuyButtonVisible = expectedResult;
            Assert.That(postViewModel.BuyButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BidButtonVisible_GetDefaultValue_ReturnsCorrectValue()
        {
            string expectedResult = Constants.COLLAPSED_VISIBILITY;
            Assert.That(postViewModel.BidButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BidButtonVisible_SetValue_SetsCorrectValue()
        {
            string expectedResult = Constants.VISIBLE_VISIBILITY;
            postViewModel.BidButtonVisible = expectedResult;
            Assert.That(postViewModel.BidButtonVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BidPriceVisible_GetDefaultValue_ReturnsCorrectValue()
        {
            string expectedResult = Constants.COLLAPSED_VISIBILITY;
            Assert.That(postViewModel.BidPriceVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BidPriceVisible_SetValue_SetsCorrectValue()
        {
            string expectedResult = Constants.VISIBLE_VISIBILITY;
            postViewModel.BidPriceVisible = expectedResult;
            Assert.That(postViewModel.BidPriceVisible, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Username_AnyUser_ReturnsCorrectValue()
        {
            string expectedUsername = "expected Username";
            User user = new User(expectedUsername, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.OurUser = user;

            Assert.That(postViewModel.Username, Is.EqualTo(expectedUsername));
        }

        [Test]
        public void Media_PostOfUnknownType_ReturnsCorrectValue()
        {
            string expectedMedia = "expected Media";
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(expectedMedia, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Media, Is.EqualTo(expectedMedia));
        }

        [Test]
        public void Location_PostOfUnknownType_ReturnsCorrectValue()
        {
            string expectedLocation = "expected Location";
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), expectedLocation, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Location, Is.EqualTo(expectedLocation));
        }

        [Test]
        public void ProfilePicture_AnyUser_ReturnsCorrectValue()
        {
            string expectedProfilePicture = "expected Profile Picture Path";
            User user = new User(string.Empty, string.Empty, DateOnly.MaxValue, expectedProfilePicture, string.Empty);
            postViewModel.OurUser = user;

            Assert.That(postViewModel.ProfilePicture, Is.EqualTo(expectedProfilePicture));
        }

        [Test]
        public void TimePosted_AnyPost_ReturnsCorrectStringForTotalSecondsLessThan60()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            TimeSpan timePassed = DateTime.Now - noTypeMarketplacePost.CreationDate;
            string expectedResult = Math.Ceiling(timePassed.TotalSeconds).ToString() + PostContentViewModel.SECONDS_AGO;
            string actualResult = postViewModel.TimePosted;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TimePosted_AnyPost_ReturnsCorrectStringForTotalMinutesLessThan60()
        {
            DateTime creationDate = DateTime.Now.AddMinutes(-30);
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            typeof(MarketplacePost).GetProperty("CreationDate").SetValue(noTypeMarketplacePost, creationDate);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            TimeSpan timePassed = DateTime.Now - creationDate;
            string expectedResult = Math.Ceiling(timePassed.TotalMinutes).ToString() + PostContentViewModel.MINUTES_AGO;

            string actualResult = postViewModel.TimePosted;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TimePosted_AnyPost_ReturnsCorrectStringForTotalHoursLessThan24()
        {
            DateTime creationDate = DateTime.Now.AddHours(-12);
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            typeof(MarketplacePost).GetProperty("CreationDate").SetValue(noTypeMarketplacePost, creationDate);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            TimeSpan timePassed = DateTime.Now - creationDate;
            string expectedResult = Math.Ceiling(timePassed.TotalHours).ToString() + " hours ago";

            string actualResult = postViewModel.TimePosted;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TimePosted_AnyPost_ReturnsCorrectStringForTotalHoursMoreThan24()
        {
            DateTime creationDate = DateTime.Now.AddDays(-12);
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            typeof(MarketplacePost).GetProperty("CreationDate").SetValue(noTypeMarketplacePost, creationDate);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            TimeSpan timePassed = DateTime.Now - creationDate;
            string expectedResult = Math.Ceiling(timePassed.TotalDays).ToString() + " days ago";

            string actualResult = postViewModel.TimePosted;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetPost_AnyPost_PostIsCorrectlyReturned()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.GetPost, Is.EqualTo(noTypeMarketplacePost));
        }

        [Test]
        public void Price_ForFixedPricePost_ReturnsCorrectValue()
        {
            double expectedPrice = 1234;
            MarketplacePost fixedPriceMarketplacePost = new FixedPriceMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty,
                string.Empty, string.Empty, string.Empty, expectedPrice, DateTime.Now, string.Empty, Guid.NewGuid(), Constants.FIXED_PRICE_POST_TYPE, true);
            postViewModel.MarketplacePost = fixedPriceMarketplacePost;

            string expectedResult = Constants.DOLLAR_SIGN + expectedPrice;

            Assert.That(postViewModel.Price, Is.EqualTo(expectedResult));
        }
        [Test]
        public void Price_ForAuctionPost_ReturnsCorrectValue()
        {
            double expectedPrice = 1234;
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, expectedPrice, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), 0, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            string expectedResult = Constants.DOLLAR_SIGN + expectedPrice;

            Assert.That(postViewModel.Price, Is.EqualTo(expectedResult));
        }
        [Test]
        public void Price_ForDonationOrUnknownPostType_ReturnsEmptyString()
        {
            string expectedPrice = Constants.EMPTY_STRING;
            MarketplacePost donationMarketplacePost = new DonationMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Constants.DONATION_POST_TYPE, true);
            postViewModel.MarketplacePost = donationMarketplacePost;

            Assert.That(postViewModel.Price, Is.EqualTo(expectedPrice));

            expectedPrice = Constants.EMPTY_STRING;
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.Price, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void UpdateBidPrice_ForAuctionPostLessThanThirtySeconds_UpdatesCorrectly()
        {
            double currentBidPrice = 1234;
            double currentMinimumBidPrice = 1000;
            DateTime expirationDate = DateTime.Now.AddSeconds(10);
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, expirationDate, string.Empty, Guid.NewGuid(), Guid.NewGuid(), currentBidPrice, currentMinimumBidPrice, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            postViewModel.UpdateBidPrice();
            double expectedBidPrice = currentBidPrice + 5;
            double expectedMinimumBidPrice = currentMinimumBidPrice + 5;
            Assert.That(((FixedPriceMarketplacePost)postViewModel.MarketplacePost).ExpirationDate, Is.EqualTo(expirationDate.AddSeconds(30)));
            Assert.That(((AuctionMarketplacePost)postViewModel.MarketplacePost).CurrentBidPrice, Is.EqualTo(expectedBidPrice));
            Assert.That(((AuctionMarketplacePost)postViewModel.MarketplacePost).MinimumBidPrice, Is.EqualTo(expectedMinimumBidPrice));
        }
        [Test]
        public void UpdateBidPrice_ForAuctionPostMoreThanThirtySeconds_UpdatesCorrectly()
        {
            double currentBidPrice = 1234;
            double currentMinimumBidPrice = 1000;
            DateTime expirationDate = DateTime.Now.AddSeconds(100);
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, expirationDate, string.Empty, Guid.NewGuid(), Guid.NewGuid(), currentBidPrice, currentMinimumBidPrice, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            postViewModel.UpdateBidPrice();
            double expectedBidPrice = currentBidPrice + 5;
            double expectedMinimumBidPrice = currentMinimumBidPrice + 5;
            Assert.That(((FixedPriceMarketplacePost)postViewModel.MarketplacePost).ExpirationDate, Is.EqualTo(expirationDate));
            Assert.That(((AuctionMarketplacePost)postViewModel.MarketplacePost).CurrentBidPrice, Is.EqualTo(expectedBidPrice));
            Assert.That(((AuctionMarketplacePost)postViewModel.MarketplacePost).MinimumBidPrice, Is.EqualTo(expectedMinimumBidPrice));
        }
        [Test]
        public void UpdateBidPrice_ForNotAuctionPost_ThrowsException()
        {
            MarketplacePost donationMarketplacePost = new DonationMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Constants.DONATION_POST_TYPE, true);
            postViewModel.MarketplacePost = donationMarketplacePost;

            var exceptionMessage = Assert.Throws<Exception>(() => { postViewModel.UpdateBidPrice(); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost is not of type AuctionMarketplacePost!"));

            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            exceptionMessage = Assert.Throws<Exception>(() => { postViewModel.UpdateBidPrice(); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost is not of type AuctionMarketplacePost!"));
        }

        [Test]
        public void AddPostToFavorites_AnyValues_ShouldCallAddItemToFavorites()
        {
            postViewModel.AddPostToFavorites();

            Assert.That(fakeUserService.AddItemToFavoritesCalled, Is.EqualTo(true));
            Assert.That(fakeUserService.GroupId, Is.EqualTo(postViewModel.GroupId));
            Assert.That(fakeUserService.PostId, Is.EqualTo(postViewModel.MarketplacePost.Id));
            Assert.That(fakeUserService.AccountId, Is.EqualTo(postViewModel.AccountId));
        }

        [Test]
        public void AddPostToCart_AnyValues_ShouldCallAddItemToCart()
        {
            postViewModel.AddPostToCart();

            Assert.That(fakeUserService.AddItemToCartCalled, Is.EqualTo(true));
            Assert.That(fakeUserService.GroupId, Is.EqualTo(postViewModel.GroupId));
            Assert.That(fakeUserService.PostId, Is.EqualTo(postViewModel.MarketplacePost.Id));
            Assert.That(fakeUserService.AccountId, Is.EqualTo(postViewModel.AccountId));
        }

        [Test]
        public void BidPrice_ForAuctionPost_ReturnsCorrectValue()
        {
            double currentBidPrice = 1234;
            MarketplacePost auctionMarketplacePost = new AuctionMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                string.Empty, 0, DateTime.Now, string.Empty, Guid.NewGuid(), Guid.NewGuid(), currentBidPrice, 0, true);
            postViewModel.MarketplacePost = auctionMarketplacePost;

            string expectedResult = Constants.DOLLAR_SIGN + currentBidPrice;
            Assert.That(postViewModel.BidPrice, Is.EqualTo(expectedResult));
        }
        [Test]
        public void BidPrice_ForNotAuctionPost_ReturnsEmptyString()
        {
            MarketplacePost donationMarketplacePost = new DonationMarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Constants.DONATION_POST_TYPE, true);
            postViewModel.MarketplacePost = donationMarketplacePost;

            string expectedResult = Constants.EMPTY_STRING;
            Assert.That(postViewModel.BidPrice, Is.EqualTo(expectedResult));

            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            Assert.That(postViewModel.BidPrice, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Interests_ForAnyPost_ReturnsCorrectValue()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            noTypeMarketplacePost.AddInterestStatus(new InterestStatus(Guid.NewGuid(), Guid.NewGuid(), true));
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            int expectedCount = 1;
            string expectedResult = expectedCount.ToString() + " interested";
            Assert.That(postViewModel.Interests, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddInterests_NoPreviousInterest_AddsInterest()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            User newUser = new User(string.Empty, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.MarketplacePost = noTypeMarketplacePost;
            postViewModel.OurUser = newUser;

            postViewModel.AddInterests();

            Assert.That(postViewModel.MarketplacePost.InterestStatuses.Count, Is.EqualTo(1));
            Assert.That(postViewModel.MarketplacePost.InterestStatuses[0].PostId, Is.EqualTo(noTypeMarketplacePost.Id));
            Assert.That(postViewModel.MarketplacePost.InterestStatuses[0].InterestedUserId, Is.EqualTo(newUser.Id));
        }

        [Test]
        public void AddInterests_InterestAlreadyExists_RemovesInterest()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            User newUser = new User(string.Empty, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.MarketplacePost = noTypeMarketplacePost;
            postViewModel.OurUser = newUser;

            postViewModel.AddInterests();
            postViewModel.AddInterests();

            Assert.That(postViewModel.MarketplacePost.InterestStatuses.Count, Is.EqualTo(0));
        }

        [Test]
        public void Uninterests_AnyPost_ReturnsUninterestedNumber()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            User newUser = new User(string.Empty, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.MarketplacePost = noTypeMarketplacePost;
            postViewModel.OurUser = newUser;

            int expectedCount = 0;
            string expectedResult = expectedCount.ToString() + " uninterested";
            Assert.That(postViewModel.Uninterests, Is.EqualTo(expectedResult));

            postViewModel.AddUninterests();
            expectedCount = 1;
            expectedResult = expectedCount.ToString() + " uninterested";
            Assert.That(postViewModel.Uninterests, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddUninterests_NoPreviousUninterest_AddsUninterest()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            User newUser = new User(string.Empty, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.MarketplacePost = noTypeMarketplacePost;
            postViewModel.OurUser = newUser;

            postViewModel.AddUninterests();

            Assert.That(postViewModel.MarketplacePost.InterestStatuses.Count, Is.EqualTo(1));
            Assert.That(postViewModel.MarketplacePost.InterestStatuses[0].PostId, Is.EqualTo(noTypeMarketplacePost.Id));
            Assert.That(postViewModel.MarketplacePost.InterestStatuses[0].InterestedUserId, Is.EqualTo(newUser.Id));
        }

        [Test]
        public void AddUninterests_UninterestAlreadyExists_RemovesUninterest()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            User newUser = new User(string.Empty, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            postViewModel.MarketplacePost = noTypeMarketplacePost;
            postViewModel.OurUser = newUser;

            postViewModel.AddUninterests();
            postViewModel.AddUninterests();

            Assert.That(postViewModel.MarketplacePost.InterestStatuses.Count, Is.EqualTo(0));
        }

        [Test]
        public void SendBuyingMessage_FakeChatFactory_ShouldCallChatSendBuyingMessage()
        {
            postViewModel.SendBuyingMessage();
            FakeChat fakeChat = (FakeChat)postViewModel.OurChatFactory.OurChat;
            Assert.That(fakeChat.SendBuyingMessageCalled, Is.EqualTo(true));
        }

        [Test]
        public void HidePost_ForAnyPost_ReturnsCorrectValue()
        {
            MarketplacePost noTypeMarketplacePost = new MarketplacePost(string.Empty, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            noTypeMarketplacePost.AddInterestStatus(new InterestStatus(Guid.NewGuid(), Guid.NewGuid(), true));
            postViewModel.MarketplacePost = noTypeMarketplacePost;

            postViewModel.HidePost();
            Assert.That(postViewModel.Visible, Is.EqualTo(Constants.COLLAPSED_VISIBILITY));
        }
    }
}
