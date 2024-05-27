using ISSLab.Domain;
using ISSLab.Domain.MarketplacePosts;
using ISSLab.Services;

namespace ISSLab.ViewModel
{
    public class CreatePostViewModel : ViewModelBase, ICreatePostViewModel
    {
        /*private IPostService postService;*/ // TODO: REMOVE
        private Guid groupId;
        private Guid accountId;

        private string phoneVisibleProperty;
        private string priceVisibleProperty;
        private string conditionVisibleProperty;
        private string deliveryVisibleProperty;
        private string availabilityVisibleProperty;
        private string isDonation;
        private string donationLink;
        private string isAuction;
        private string minimumBid;
        private IApiService apiService;

        public CreatePostViewModel(Guid accountId, Guid groupId, IApiService apiService) : base()
        {
            // this.postService = postService;
            this.groupId = groupId;
            this.accountId = accountId;
            IsDonation = Constants.COLLAPSED_VISIBILITY;
            IsAuction = Constants.COLLAPSED_VISIBILITY;
            this.apiService = apiService;
        }

        private string type;
        private string phoneNumber;
        private float price;
        private string condition;
        private string delivery;
        private string availability;
        private string description;

        public string MinimumBid
        {
            get { return minimumBid; } set { minimumBid = value; }
        }
        public string IsAuction
        {
            get
            {
                return isAuction;
            }
            set
            {
                isAuction = value;
                OnPropertyChanged(IsAuction);
            }
        }
        public string DonationLink
        {
            get
            {
                return donationLink;
            }
            set
            {
                donationLink = value;
                OnPropertyChanged(nameof(DonationLink));
            }
        }
        public string IsDonation
        {
            get
            {
                return isDonation;
            }
            set
            {
                isDonation = value;
                OnPropertyChanged(nameof(IsDonation));
            }
        }
        public string PhoneVisible
        {
            get
            {
                return phoneVisibleProperty;
            }
            set
            {
                phoneVisibleProperty = value;
                OnPropertyChanged(nameof(PhoneVisible));
            }
        }
        public string PriceVisible
        {
            get
            {
                return priceVisibleProperty;
            }
            set
            {
                priceVisibleProperty = value;
                OnPropertyChanged(nameof(PriceVisible));
            }
        }
        public string ConditionVisible
        {
            get
            {
                return conditionVisibleProperty;
            }
            set
            {
                conditionVisibleProperty = value;
                OnPropertyChanged(nameof(ConditionVisible));
            }
        }
        public string DeliveryVisible
        {
            get
            {
                return deliveryVisibleProperty;
            }
            set
            {
                deliveryVisibleProperty = value;
                OnPropertyChanged(nameof(DeliveryVisible));
            }
        }
        public string AvailabilityVisible
        {
            get
            {
                return availabilityVisibleProperty;
            }
            set
            {
                availabilityVisibleProperty = value;
                OnPropertyChanged(nameof(AvailabilityVisible));
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                if (type.Contains("Fixed price"))
                {
                    IsAuction = Constants.COLLAPSED_VISIBILITY;
                    PhoneVisible = Constants.VISIBLE_VISIBILITY;
                    PriceVisible = Constants.VISIBLE_VISIBILITY;
                    ConditionVisible = Constants.VISIBLE_VISIBILITY;
                    DeliveryVisible = Constants.VISIBLE_VISIBILITY;
                    AvailabilityVisible = Constants.VISIBLE_VISIBILITY;
                    IsDonation = Constants.COLLAPSED_VISIBILITY;
                }
                else if (type.Contains(Constants.DONATION_POST_TYPE))
                {
                    PriceVisible = Constants.COLLAPSED_VISIBILITY;
                    ConditionVisible = Constants.COLLAPSED_VISIBILITY;
                    DeliveryVisible = Constants.COLLAPSED_VISIBILITY;
                    AvailabilityVisible = Constants.COLLAPSED_VISIBILITY;
                    IsDonation = Constants.VISIBLE_VISIBILITY;
                    IsAuction = Constants.COLLAPSED_VISIBILITY;
                }
                else
                {
                    IsAuction = Constants.VISIBLE_VISIBILITY;
                    IsDonation = Constants.COLLAPSED_VISIBILITY;
                    PhoneVisible = Constants.VISIBLE_VISIBILITY;
                    AvailabilityVisible = Constants.COLLAPSED_VISIBILITY;
                    ConditionVisible = Constants.COLLAPSED_VISIBILITY;
                    PriceVisible = Constants.VISIBLE_VISIBILITY;
                }

                OnPropertyChanged(nameof(Type));
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                OnPropertyChanged(nameof(Condition));
            }
        }
        public string Delivery
        {
            get
            {
                return delivery;
            }
            set
            {
                delivery = value;
                OnPropertyChanged(nameof(Delivery));
            }
        }
        public string Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
                OnPropertyChanged(nameof(Availability));
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public Guid AccountId
        {
            get { return accountId; }
        }
        public Guid GroupId
        {
            get { return groupId; }
        }
        public void CreatePost()
        {
            if (Type.Contains("Fixed price"))
            {
                CreateFixedPricePost();
            }
            else
            {
                CreateDonationPost();
            }
        }

        public async void CreateDonationPost()
        {
            MarketplacePost donationMarketplacePost = new DonationPost(Guid.NewGuid(), accountId, groupId, Constants.EMPTY_STRING,
                Description, Constants.EMPTY_STRING, Constants.EMPTY_STRING, DateTime.Now, DateTime.Now, true, true, donationLink, Price);
            // postService.AddPost(donationMarketplacePost);
            // Getting the ApiService instance
            try
            {
                // Calling the AddPostAsync method
                Uri location = await apiService.AddMarketplacePostAsync(donationMarketplacePost);
                Console.WriteLine($"Post added successfully at {location}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Dispose of ApiService when done
            apiService.Dispose();
            ResetFields();
        }

        public async void CreateFixedPricePost()
        {
            // MarketplacePost fixedPriceMarketplace = new FixedPricePost(Guid.NewGuid(), accountId, groupId, "Cluj", Description, Constants.EMPTY_STRING, Constants.EMPTY_STRING,
            //  DateTime.Now, DateTime.Now, true, true, Price, false, Delivery);
            MarketplacePost post = new MarketplacePost(Guid.NewGuid(), accountId, groupId, "Nacho", Description, Constants.EMPTY_STRING, "Cluj", DateTime.Now, null, true, true);
            post.Type = "NormalPost";
            // postService.AddPost(fixedPriceMarketplace);
            // Getting the ApiService instance
            try
            {
                // Calling the AddPostAsync method
                Uri location = await apiService.AddMarketplacePostAsync(post);
                Console.WriteLine($"Post added successfully at {location}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            ResetFields();
        }

        private void ResetFields()
        {
            Type = Constants.EMPTY_STRING;
            PhoneNumber = Constants.EMPTY_STRING;
            Price = 0;
            Condition = Constants.EMPTY_STRING;
            Delivery = Constants.EMPTY_STRING;
            Availability = Constants.EMPTY_STRING;
            Description = Constants.EMPTY_STRING;
        }
    }
}

