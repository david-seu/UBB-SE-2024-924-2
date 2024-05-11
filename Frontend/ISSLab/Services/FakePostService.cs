using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace ISSLab.Services
{
    public class FakePostService : IPostService
    {
        public bool GetPostsCalled;
        public void AddPost(MarketplacePost marketplacePost)
        {
            throw new NotImplementedException();
        }

        public void AddReport(Guid postID, Guid userID, string reason)
        {
            throw new NotImplementedException();
        }

        public void BidOnAuction(Guid postID, Guid userID, double bidAmount)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfAuctionTimeEnded(Guid postID)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfNeedsConfirmation(Guid postID)
        {
            throw new NotImplementedException();
        }

        public void ConfirmPost(Guid postID)
        {
            throw new NotImplementedException();
        }

        public MarketplacePost CreateAuctionPost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, double price, DateTime expirationDate, string delivery, Guid buyerId, Guid currentPriceLeader, double currentBidPrice, double minimumBidPrice)
        {
            throw new NotImplementedException();
        }

        public MarketplacePost CreateDonationPost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, string donationPageLink)
        {
            throw new NotImplementedException();
        }

        public MarketplacePost CreateFixedPricePost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, double price, DateTime expirationDate, string delivery, Guid buyerId)
        {
            throw new NotImplementedException();
        }

        public MarketplacePost CreatePost(string media, Guid authorId, Guid groupId, string location, string description, string title, string contacts, string type)
        {
            throw new NotImplementedException();
        }

        public void Donate(Guid postID)
        {
            throw new NotImplementedException();
        }

        public void EndAuctionDueToTime(Guid postID)
        {
            throw new NotImplementedException();
        }

        public void EndAuctionExplicitly(Guid postID, Guid userID)
        {
            throw new NotImplementedException();
        }

        public void FavoritePost(Guid postID, Guid userID)
        {
            throw new NotImplementedException();
        }

        public MarketplacePost GetPostById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<MarketplacePost> GetPosts()
        {
            GetPostsCalled = true;
            string expectedMediaContent = "expected Media Content";
            MarketplacePost dummyMarketplacePost = new MarketplacePost(expectedMediaContent, Guid.NewGuid(), Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            return new List<MarketplacePost> { dummyMarketplacePost };
        }

        public IEnumerable<MarketplacePost> GetPostsByFavorites(List<MarketplacePost> postsForGroup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MarketplacePost> GetPostsMainMarketPage(List<MarketplacePost> postsForGroup)
        {
            throw new NotImplementedException();
        }

        public void PromotePost(Guid postID, Guid userID, Guid groupID)
        {
            throw new NotImplementedException();
        }

        public void RemoveConfirmation(Guid postID)
        {
            throw new NotImplementedException();
        }

        public void RemoveOldFixedPricePosts()
        {
            throw new NotImplementedException();
        }

        public void RemovePost(MarketplacePost marketplacePost)
        {
            throw new NotImplementedException();
        }

        public void RemoveReport(Guid postID, Guid userID)
        {
            throw new NotImplementedException();
        }

        public void ToggleInterest(Guid postID, Guid userID, bool interested)
        {
            throw new NotImplementedException();
        }

        public void UnfavoritePost(Guid postID, Guid userID)
        {
            throw new NotImplementedException();
        }
    }
}
