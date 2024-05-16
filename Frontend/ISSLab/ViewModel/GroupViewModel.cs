using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ISSLab.Domain;
using ISSLab.Model.Entities;
using ISSLab.ViewModel;
using ISSLab.Services;
using User = ISSLab.Domain.User;

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

        public ObservableCollection<User> GroupMembers
        {
            get; set;
        }

        public ObservableCollection<Request> RequestsToJoinTheGroup
        {
            get; set;
        }

        public ObservableCollection<Post> PostsMadeInTheGroupChat
        {
            get; set;
        }

        public GroupViewModel(Group selectedGroup)
        {
            GroupThatIsEncapsulatedByThisInstanceOnViewModel = selectedGroup;

            FetchPosts();
            FetchPolls();
            FetchRequestsToJoinGroup();
            FetchGroupMembers();

            // TODO: Fetch posts and members from the repository

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
                List<Post> groupPosts = await apiService.GetGroupPosts(GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupId);
                Console.WriteLine($"Successfully fetched the group posts");

                PostsMadeInTheGroupChat = new ObservableCollection<Post>(
                groupPosts.Select(post => new Post(post.MediaContent, post.AuthorId, post.GroupId, post.ItemLocation, post.Description, post.Title, post.Contacts, post.Type, post.Confirmed)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }

            // nu il folositi ca strica tot (Bianca asa o zis)
            // apiService.Dispose();
        }

        public async void FetchRequestsToJoinGroup()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Request> requestsToJoinGroup =
                    await apiService.GetRequestsToJoinGroup(GroupThatIsEncapsulatedByThisInstanceOnViewModel
                        .Id);
                Console.WriteLine($"Successfully fetched the group posts");

                RequestsToJoinTheGroup = new ObservableCollection<Request>(
                    requestsToJoinGroup.Select(request =>
                        new Request(request.Id, request.GroupMemberId, request.GroupMemberName, request.GroupId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }

            // nu il folositi ca strica tot (Bianca asa o zis)
            // apiService.Dispose();
        }

        public async void FetchGroupMembers()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<User> groupMembers = await apiService.GetGroupMembers(GroupThatIsEncapsulatedByThisInstanceOnViewModel.Id);
                Console.WriteLine($"Successfully fetched the group members");

                GroupMembers = new ObservableCollection<User>(
                    groupMembers.Select(member => new User(member.UserId, member.Username, member.Password, member.Email, member.PhoneNumber, member.FullName)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group MEMBERS: {ex.Message}");
            }

            // nu il folositi ca strica tot (Bianca asa o zis)
            // apiService.Dispose();
        }

        public async void FetchPolls()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Poll> groupPolls = await apiService.GetGroupPolls(GroupThatIsEncapsulatedByThisInstanceOnViewModel.Id);
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
        private Group groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel;
        public Group GroupThatIsEncapsulatedByThisInstanceOnViewModel
        {
            get
            {
                return this.groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel;
            }
            set
            {
                this.groupMarketplaceThatIsEncapsulatedByThisInstanceOnViewModel = value;
                OnPropertyChanged(nameof(GroupThatIsEncapsulatedByThisInstanceOnViewModel));
            }
        }

        public string GroupName
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.Name;
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.Name = value;
                // TODO: notify somehow the main window view model that Name has changed
                OnPropertyChanged(nameof(GroupName));
            }
        }

        // public string DirectoryPathToTheGroupsBannerImageFile
        // {
        //    get
        //    {
        //        return GroupThatIsEncapsulatedByThisInstanceOnViewModel.;
        //    }
        // }
        // Group Settings Tab
        public string NameOfTheGroupsOwner
        {
            // TODO: Fetch owner name from the repository
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.OwnerId.ToString();
            }
        }

        // nush redenumi asta
        public string UniqueGroupCode
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupCode;
            }
        }

        public string DateOfCreationInStringFormat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.CreatedAt.ToString();
            }
        }

        public string MemberCounterInStringFormat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.MemberCount.ToString();
            }
        }

        public string PostCounterInStringFormat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.Posts.Count.ToString();
            }
        }

        public string RequestCounterInStringFormat
        {
            get
            {
                // ma everva ca afisa 0. DACA codul ar merge, ai folosi ca mai sus
                return RequestsToJoinTheGroup.Count.ToString();
                // return GroupThatIsEncapsulatedByThisInstanceOnViewModel.RequestCount.ToString();
            }
        }

        public string IsTheGroupPublicToOutsiders
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.IsPublic == true ? "Public" : "Private";
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.IsPublic = value == "Public";
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
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.Description;
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.Description = value;
                OnPropertyChanged(nameof(DescriptionOfTheGroup));
            }
        }

        public string MaximumAmountOfPostsAllowed
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.MaxPostsPerHourPerUser.ToString();
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.MaxPostsPerHourPerUser = int.Parse(value);
                OnPropertyChanged(nameof(MaximumAmountOfPostsAllowed));
            }
        }

        public string AllowanceOfPostageOnTheGroupChat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.CanMakePostsByDefault == true ? "Yes" : "No";
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.CanMakePostsByDefault = value == "Yes";
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
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.Icon;
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.Icon = value;
                // TODO: notify somehow the main window view model that IconPath has changed
                // OnPropertyChanged("IconPath");
                OnPropertyChanged(nameof(NameOfTheGroupsIcon));
            }
        }

        public string NameOfTheGroupsBanner
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.Banner;
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.Banner = value;
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
