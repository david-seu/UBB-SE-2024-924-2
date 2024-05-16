using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Threading;
using ISSLab.Domain;
using ISSLab.Domain.MarketplacePosts;
using ISSLab.Services;
using ISSLab.View;

namespace ISSLab.ViewModel
{
    public class PostContentViewModel : ViewModelBase, IPostContentViewModel
    {
        public static string MINUTES_AGO = " minutes ago";
        public static string SECONDS_AGO = " seconds ago";

        private IUserService userService;
        public Guid GroupId { get; set; }
        private MarketplacePost OurMarketplacePost { get; set; }
        public Guid AccountId { get; set; }
        public User OurUser;
        private string visible;
        private string donationButtonVisible;
        private string buyButtonVisible;
        private string bidButtonVisible;
        private string bidPriceVisible;
        private DispatcherTimer timer;
        public IChatFactory OurChatFactory { get; }
        public PostContentViewModel(MarketplacePost marketplacePost, User user, Guid accountId, Guid groupId, IUserService userService, IChatFactory chatFactory) : base()
        {
            this.userService = userService;
            this.GroupId = groupId;
            this.AccountId = accountId;
            this.OurMarketplacePost = marketplacePost;
            this.OurUser = user;
            this.visible = Constants.VISIBLE_VISIBILITY;
            this.donationButtonVisible = Constants.COLLAPSED_VISIBILITY;
            this.buyButtonVisible = Constants.COLLAPSED_VISIBILITY;
            this.bidButtonVisible = Constants.COLLAPSED_VISIBILITY;
            this.bidPriceVisible = Constants.COLLAPSED_VISIBILITY;
            if (this.OurMarketplacePost.Description == Constants.DONATION_POST_TYPE)
            {
                this.donationButtonVisible = Constants.VISIBLE_VISIBILITY;
            }
            else if (this.OurMarketplacePost.Description == Constants.FIXED_PRICE_POST_TYPE)
            {
                this.buyButtonVisible = Constants.VISIBLE_VISIBILITY;
            }
            else if (this.OurMarketplacePost.Description == Constants.AUCTION_POST_TYPE)
            {
                this.buyButtonVisible = Constants.VISIBLE_VISIBILITY;
                this.bidButtonVisible = Constants.VISIBLE_VISIBILITY;
                this.bidPriceVisible = Constants.VISIBLE_VISIBILITY;
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            this.OurChatFactory = chatFactory;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(AvailableFor));
        }
        public MarketplacePost MarketplacePost
        {
            get { return OurMarketplacePost; }
            set { OurMarketplacePost = value; }
        }

        public string Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        public string Description
        {
            get { return OurMarketplacePost.Description; }
            set { OurMarketplacePost.Description = value; }
        }

        public string Delivery
        {
            get
            {
                if (OurMarketplacePost.Description == Constants.FIXED_PRICE_POST_TYPE)
                {
                    FixedPricePost fixedPriceMarketplacePost = (FixedPricePost)OurMarketplacePost;
                    return fixedPriceMarketplacePost.DeliveryType;
                }
                else if (OurMarketplacePost.Description == Constants.AUCTION_POST_TYPE)
                {
                    AuctionPost auctionMarketplacePost = (AuctionPost)OurMarketplacePost;
                    return auctionMarketplacePost.Delivery;
                }
                else
                {
                    return Constants.EMPTY_STRING;
                }
            }
            set
            {
                if (OurMarketplacePost.Type == Constants.FIXED_PRICE_POST_TYPE)
                {
                    FixedPriceMarketplacePost fixedPriceMarketplacePost = (FixedPriceMarketplacePost)OurMarketplacePost;
                    fixedPriceMarketplacePost.Delivery = value;
                }
                else if (OurMarketplacePost.Type == Constants.AUCTION_POST_TYPE)
                {
                    AuctionMarketplacePost auctionMarketplacePost = (AuctionMarketplacePost)OurMarketplacePost;
                    auctionMarketplacePost.Delivery = value;
                }
            }
        }

        public string DonationButtonVisible
        {
            get
            {
                return donationButtonVisible;
            }
            set
            {
                donationButtonVisible = value;
                OnPropertyChanged(nameof(DonationButtonVisible));
            }
        }

        public string BuyButtonVisible
        {
            get
            {
                return buyButtonVisible;
            }
            set
            {
                buyButtonVisible = value;
                OnPropertyChanged(nameof(BuyButtonVisible));
            }
        }

        public string BidButtonVisible
        {
            get
            {
                return bidButtonVisible;
            }
            set
            {
                bidButtonVisible = value;
                OnPropertyChanged(nameof(BidButtonVisible));
            }
        }

        public string BidPriceVisible
        {
            get
            {
                return bidPriceVisible;
            }
            set
            {
                bidPriceVisible = value;
                OnPropertyChanged(nameof(BidPriceVisible));
            }
        }

        public string Username
        {
            get
            {
                return OurUser.Username;
            }
        }

        public string Media
        {
            get
            {
                return OurMarketplacePost.MediaContent;
            }
        }

        public string Location
        {
            get
            {
                return OurMarketplacePost.ItemLocation;
            }
        }

        public string ProfilePicture
        {
            get
            {
                return OurUser.ProfilePicture;
            }
        }
        public string TimePosted
        {
            get
            {
                TimeSpan passed = DateTime.Now - OurMarketplacePost.CreationDate;
                if (passed.TotalSeconds < 60)
                {
                    return Math.Ceiling(passed.TotalSeconds).ToString() + SECONDS_AGO;
                }
                if (passed.TotalMinutes < 60)
                {
                    return Math.Ceiling(passed.TotalMinutes).ToString() + MINUTES_AGO;
                }
                if (passed.TotalHours < 24)
                {
                    return Math.Ceiling(passed.TotalHours).ToString() + " hours ago";
                }

                return Math.Ceiling(passed.TotalDays).ToString() + " days ago";
            }
        }

        public MarketplacePost GetPost()
        {
            return OurMarketplacePost;
        }

        public void AddPostToFavorites()
        {
            this.userService.AddPostToFavorites(GroupId, OurMarketplacePost.Id, AccountId);
        }

        public async void AddPostToCart()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                await apiService.AddPostToCart(this.GroupId, this.MarketplacePost.Id, this.AccountId);
                Console.WriteLine($"Successfully added the post to the cart");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error while adding the post to the cart: {exception.Message}");
            }

            apiService.Dispose();
        }

        public string AvailableFor
        {
            get
            {
                if (OurMarketplacePost.Type == Constants.FIXED_PRICE_POST_TYPE)
                {
                    FixedPriceMarketplacePost fixedPriceMarketplacePost = (FixedPriceMarketplacePost)OurMarketplacePost;
                    TimeSpan timeLeft = fixedPriceMarketplacePost.ExpirationDate - DateTime.Now;
                    return DisplayRemainingTime(timeLeft);
                }
                else if (OurMarketplacePost.Type == Constants.AUCTION_POST_TYPE)
                {
                    AuctionMarketplacePost fixedPriceMarketplacePost = (AuctionMarketplacePost)OurMarketplacePost;
                    TimeSpan timeLeft = fixedPriceMarketplacePost.ExpirationDate - DateTime.Now;
                    return DisplayRemainingTime(timeLeft);
                }
                else
                {
                    return Constants.EMPTY_STRING;
                }
            }
        }

        public string DisplayRemainingTime(TimeSpan timeLeft)
        {
            if (timeLeft.TotalSeconds < 60)
            {
                return "Available for: " + Math.Ceiling(timeLeft.TotalSeconds).ToString() + " seconds";
            }
            if (timeLeft.TotalMinutes < 60)
            {
                return "Available for: " + Math.Ceiling(timeLeft.TotalMinutes).ToString() + " minutes";
            }
            if (timeLeft.TotalHours < 24)
            {
                return "Available for: " + Math.Ceiling(timeLeft.TotalHours).ToString() + " hours";
            }
            return "Available for: " + Math.Ceiling(timeLeft.TotalDays).ToString() + " days";
        }

        public string Price
        {
            get
            {
                if (OurMarketplacePost.Type == Constants.FIXED_PRICE_POST_TYPE)
                {
                    return Constants.DOLLAR_SIGN + ((FixedPriceMarketplacePost)(OurMarketplacePost)).Price;
                }
                else if (OurMarketplacePost.Type == Constants.AUCTION_POST_TYPE)
                {
                    return Constants.DOLLAR_SIGN + ((AuctionMarketplacePost)(OurMarketplacePost)).Price;
                }
                else
                {
                    return Constants.EMPTY_STRING;
                }
            }
        }

        public void UpdateBidPrice()
        {
            if (OurMarketplacePost.GetType() == typeof(AuctionMarketplacePost))
            {
                AuctionMarketplacePost auctionMarketplacePost = (AuctionMarketplacePost)OurMarketplacePost;
                TimeSpan timeLeft = auctionMarketplacePost.ExpirationDate - DateTime.Now;
                TimeSpan timeSpan = TimeSpan.FromSeconds(Constants.EXPIRATION_DATE_SLIGHT_PROLONGMENT_THRESHOLD_IN_SECONDS);
                if (timeLeft.TotalSeconds < Constants.EXPIRATION_DATE_SLIGHT_PROLONGMENT_THRESHOLD_IN_SECONDS)
                {
                    auctionMarketplacePost.SlightlyPostponeExpirationDate();
                    OnPropertyChanged(nameof(AvailableFor));
                }
            ((AuctionMarketplacePost)(OurMarketplacePost)).CurrentBidPrice += 5;
                ((AuctionMarketplacePost)(OurMarketplacePost)).MinimumBidPrice += 5;
                OnPropertyChanged(nameof(BidPrice));
            }
            else
            {
                throw new Exception("MarketplacePost is not of type AuctionMarketplacePost!");
            }
        }

        public string BidPrice
        {
            get
            {
                if (OurMarketplacePost.Type == Constants.AUCTION_POST_TYPE)
                {
                    return Constants.DOLLAR_SIGN + ((AuctionMarketplacePost)(OurMarketplacePost)).CurrentBidPrice;
                }
                else
                {
                    return Constants.EMPTY_STRING;
                }
            }
        }

        public string Interests
        {
            get
            {
                int interested = OurMarketplacePost.InterestStatuses.FindAll(interest => interest.Interested).Count;
                return interested.ToString() + " interested";
            }
        }

        public void AddInterests()
        {
            var existingInterest = OurMarketplacePost.InterestStatuses.FirstOrDefault(interest => interest.InterestedUserId == OurUser.Id && interest.PostId == OurMarketplacePost.Id);

            if (existingInterest != null)
            {
                OurMarketplacePost.InterestStatuses.Remove(existingInterest);
            }
            else
            {
                OurMarketplacePost.InterestStatuses.Add(new InterestStatus(OurUser.Id, OurMarketplacePost.Id, true));
            }

            OnPropertyChanged(nameof(Interests));
        }

        public string Uninterests
        {
            get
            {
                int uninterested = OurMarketplacePost.InterestStatuses.FindAll(interest => !interest.Interested).Count;
                return uninterested.ToString() + " uninterested";
            }
        }

        public void AddUninterests()
        {
            var existingUninterest = OurMarketplacePost.InterestStatuses.FirstOrDefault(interest => interest.InterestedUserId == OurUser.Id && interest.PostId == OurMarketplacePost.Id && !interest.Interested);

            if (existingUninterest != null)
            {
                OurMarketplacePost.InterestStatuses.Remove(existingUninterest);
            }
            else
            {
                OurMarketplacePost.InterestStatuses.Add(new InterestStatus(OurUser.Id, OurMarketplacePost.Id, false));
            }
            OnPropertyChanged(nameof(Uninterests));
        }

        public void SendBuyingMessage()
        {
            var chatViewModel = new ChatViewModel(OurUser, OurMarketplacePost);
            IChat chat = OurChatFactory.CreateChat(chatViewModel);
            chat.SendBuyingMessage(Media);
            chat.Show();
        }

        public void Donate()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = ((DonationMarketplacePost)OurMarketplacePost).DonationPageLink,
                UseShellExecute = true
            });
        }

        public void HidePost()
        {
            Visible = Constants.COLLAPSED_VISIBILITY;
        }
    }
}
