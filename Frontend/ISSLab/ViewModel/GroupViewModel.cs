using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ISSLab.Model.Entities;
using ISSLab.ViewModel;
using ISSLab.Services;

namespace ISSLab.ViewModel
{
    public class GroupViewModel : ViewModelBase
    {
        public ObservableCollection<Poll> CollectionOfPolls
        {
            get; set;
        }

        public ObservableCollection<PollViewModel> CollectionOfViewModelsForEachIndividualPoll
        {
            get; set;
        }

        public ObservableCollection<GroupMember> GroupMembers
        {
            get; set;
        }

        public ObservableCollection<Request> RequestsToJoinTheGroup
        {
            get; set;
        }

        public ObservableCollection<GroupPost> PostsMadeInTheGroupChat
        {
            get; set;
        }

        public GroupViewModel(GroupNonMarketplace selectedGroup)
        {
            GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel = selectedGroup;

            FetchPosts();
            FetchPolls();

            // TODO: Fetch posts and members from the repository
            GroupMembers = new ObservableCollection<GroupMember>
            {
                new GroupMember(Guid.NewGuid(), "Denis", "admin", "denis@ubb.ro", "0749999345", "I am stupid."),
                new GroupMember(Guid.NewGuid(), "Andreea", "admin", "denis@ubb.ro", "0749999345", "I am stupid."),
                new GroupMember(Guid.NewGuid(), "Dorian Pop", "admin", "denis@ubb.ro", "0749999345", "I am stupid."),
                new GroupMember(Guid.NewGuid(), "Razvan", "admin", "denis@ubb.ro", "0749999345", "I am stupid."),
                new GroupMember(Guid.NewGuid(), "Cristi", "admin", "denis@ubb.ro", "0749999345", "I am stupid."),
                new GroupMember(Guid.NewGuid(), "Cristos", "admin", "denis@ubb.ro", "0749999345", "I am stupid.")
            };

            RequestsToJoinTheGroup = new ObservableCollection<Request>()
            {
                new Request(Guid.NewGuid(), Guid.NewGuid(), "Vasile", Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), "Andrei", Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), "Maria", Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), "Gabriel", Guid.NewGuid())
            };

            List<PollViewModel> pollViewModels = new List<PollViewModel>();
            foreach (Poll poll in CollectionOfPolls)
            {
                pollViewModels.Add(new PollViewModel(poll));
            }
            CollectionOfViewModelsForEachIndividualPoll = new ObservableCollection<PollViewModel>(pollViewModels);
        }

        public async void FetchPosts()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<GroupPost> groupPosts = await apiService.GetGroupPosts(GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Id);
                Console.WriteLine($"Successfully fetched the group posts");

                PostsMadeInTheGroupChat = new ObservableCollection<GroupPost>(
                groupPosts.Select(post => new GroupPost(post.Id, post.OwnerId, post.Description, post.Image, post.GroupId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }


            // nu il folositi ca strica tot (Bianca asa o zis)
            apiService.Dispose();
        }

        public async void FetchPolls()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Poll> groupPolls = await apiService.GetGroupPolls(GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Id);
                Console.WriteLine($"Successfully fetched the group polls");

                foreach (Poll poll in groupPolls)
                {
                    poll.AddOption("Yes");
                    poll.AddOption("No");
                    poll.AddOption("Maybe");
                    poll.AddOption("I don't want to answer");
                }
                CollectionOfPolls = new ObservableCollection<Poll>(groupPolls);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POLLS: {ex.Message}");
            }

            apiService.Dispose();
        }

        private Poll currentlySelectedPoll;
        public Poll CurrentlySelectedPoll
        {
            get
            {
                return this.currentlySelectedPoll;
            }
            set
            {
                this.currentlySelectedPoll = value;
                OnPropertyChanged(nameof(CurrentlySelectedPoll));
            }
        }

        private PollViewModel viewModelCorrecpondingToCurrentlySelectedPoll;
        public PollViewModel ViewModelCorrecpondingToCurrentlySelectedPoll
        {
            get
            {
                return this.viewModelCorrecpondingToCurrentlySelectedPoll;
            }
            set
            {
                this.viewModelCorrecpondingToCurrentlySelectedPoll = value;
                OnPropertyChanged(nameof(ViewModelCorrecpondingToCurrentlySelectedPoll));
            }
        }

        // ???
        private GroupNonMarketplace groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel;
        public GroupNonMarketplace GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel
        {
            get
            {
                return this.groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel;
            }
            set
            {
                this.groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel = value;
                OnPropertyChanged(nameof(GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel));
            }
        }

        public string GroupName
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Name;
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Name = value;
                // TODO: notify somehow the main window view model that Name has changed
                OnPropertyChanged(nameof(GroupName));
            }
        }

        public string DirectoryPathToTheGroupsBannerImageFile
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.BannerPath;
            }
        }
        // GroupNonMarketplace Settings Tab
        public string NameOfTheGroupsOwner
        {
            // TODO: Fetch owner name from the repository
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.OwnerId.ToString();
            }
        }

        // nush redenumi asta
        public string UniqueGroupCode
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.GroupCode;
            }
        }

        public string DateOfCreationInStringFormat
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.CreatedAt.ToString();
            }
        }

        public string MemberCounterInStringFormat
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.MemberCount.ToString();
            }
        }

        public string PostCounterInStringFormat
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Posts.Count.ToString();
            }
        }

        public string RequestCounterInStringFormat
        {
            get
            {
                // ma everva ca afisa 0. DACA codul ar merge, ai folosi ca mai sus
                return RequestsToJoinTheGroup.Count.ToString();
                // return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.RequestCount.ToString();
            }
        }

        public string IsTheGroupPublicToOutsiders
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.IsPublic == true ? "Public" : "Private";
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.IsPublic = value == "Public";
                OnPropertyChanged(nameof(IsTheGroupPublicToOutsiders));
            }
        }

        public RelayCommand ChangePrivacyPolicyCommand => new RelayCommand(execute => ChangePrivacyPolicyOfTheGroup());

        private void ChangePrivacyPolicyOfTheGroup()
        {
            IsTheGroupPublicToOutsiders = IsTheGroupPublicToOutsiders == "Public" ? "Private" : "Public";
        }

        public string DescriptionOfTheGroup
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Description;
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Description = value;
                OnPropertyChanged(nameof(DescriptionOfTheGroup));
            }
        }

        public string MaximumAmountOfPostsAllowed
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.MaxPostsPerHourPerUser.ToString();
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.MaxPostsPerHourPerUser = int.Parse(value);
                OnPropertyChanged(nameof(MaximumAmountOfPostsAllowed));
            }
        }

        public string AllowanceOfPostageOnTheGroupChat
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.CanMakePostsByDefault == true ? "Yes" : "No";
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.CanMakePostsByDefault = value == "Yes";
                OnPropertyChanged(nameof(AllowanceOfPostageOnTheGroupChat));
            }
        }

        public RelayCommand ChangeAllowanceOfPostageCommand => new RelayCommand(execute => ChangeAllowanceOfPostage());

        private void ChangeAllowanceOfPostage()
        {
            AllowanceOfPostageOnTheGroupChat = AllowanceOfPostageOnTheGroupChat == "Yes" ? "No" : "Yes";
        }

        /// cum plm poate fi o iconita string???
        public string NameOfTheGroupsIcon
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Icon;
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Icon = value;
                // TODO: notify somehow the main window view model that IconPath has changed
                // OnPropertyChanged("IconPath");
                OnPropertyChanged(nameof(NameOfTheGroupsIcon));
            }
        }

        public string NameOfTheGroupsBanner
        {
            get
            {
                return GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Banner;
            }
            set
            {
                GroupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel.Banner = value;
                OnPropertyChanged(nameof(NameOfTheGroupsBanner));
                OnPropertyChanged("BannerPath");
            }
        }
        // Requests
        public RelayCommand AcceptJoinRequestCommand => new RelayCommand(execute => AcceptJoinRequest());

        private void AcceptJoinRequest()
        {
        }

        public RelayCommand RejectJoinRequestCommand => new RelayCommand(execute => RejectJoinRequest());

        private void RejectJoinRequest()
        {
        }
    }
}
