using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ISSLab.ViewModel;
using ISSLab.Domain;
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

            // TODO: Fetch posts and members from the repository
            GroupMembers = new ObservableCollection<User>
            {
                new User(Guid.NewGuid(), "Denis", "Denis Popescu", "admin", "denis@ubb.ro", "0749999345"),
                new User(Guid.NewGuid(), "Andreea", "Andreea Popescu", "admin", "denis@ubb.ro", "0749999345"),
                new User(Guid.NewGuid(), "Dorian Pop", "Dorian Pop Popescu", "admin", "denis@ubb.ro", "0749999345"),
                new User(Guid.NewGuid(), "Razvan", "Razvan Popescu", "admin", "denis@ubb.ro", "0749999345"),
                new User(Guid.NewGuid(), "Cristi", "Cristi Popescu", "admin", "denis@ubb.ro", "0749999345"),
                new User(Guid.NewGuid(), "Cristos", "Cristos Popescu", "admin", "denis@ubb.ro", "0749999345")
            };

            RequestsToJoinTheGroup = new ObservableCollection<Request>()
            {
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
                new Request(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())
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
                List<Post> groupPosts = await apiService.GetGroupPosts(GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupId);
                Console.WriteLine($"Successfully fetched the group posts");

                PostsMadeInTheGroupChat = new ObservableCollection<Post>(
                groupPosts.Select(post => new Post(post.MediaContent, post.AuthorId, post.GroupId, post.ItemLocation, post.Description, post.Title, post.Contacts, post.Type, post.Confirmed)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }
        }

        public async void FetchRequestsToJoinGroup()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Request> requestsToJoinGroup =
                    await apiService.GetRequestsToJoinGroup(GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupId);
                Console.WriteLine($"Successfully fetched the group posts");

                RequestsToJoinTheGroup = new ObservableCollection<Request>(
                    requestsToJoinGroup.Select(request =>
                        new Request(request.JoinRequestId, request.UserId, request.GroupId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }
        }

        public async void FetchGroupMembers()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<User> groupMembers = await apiService.GetGroupMembers(GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupId);
                Console.WriteLine($"Successfully fetched the group members");

                GroupMembers = new ObservableCollection<User>(
                    groupMembers.Select(member => new User(member.UserId, member.Username, member.FullName, member.Password, member.Email, member.PhoneNumber)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group MEMBERS: {ex.Message}");
            }
        }

        public async void FetchPolls()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Poll> groupPolls = await apiService.GetGroupPolls(GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupId);
                Console.WriteLine($"Successfully fetched the group polls");

                foreach (Poll poll in groupPolls)
                {
                    poll.PollOptions.Add(new PollOption(poll.PollId, "Yes"));
                    poll.PollOptions.Add(new PollOption(poll.PollId, "No"));
                    poll.PollOptions.Add(new PollOption(poll.PollId, "Maybe"));
                    poll.PollOptions.Add(new PollOption(poll.PollId, "I don't want to answer"));
                }
                CollectionOfPolls = new ObservableCollection<Poll>(groupPolls);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POLLS: {ex.Message}");
            }
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
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupName;
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.GroupName = value;
                // TODO: notify somehow the main window view model that Name has changed
                OnPropertyChanged(nameof(GroupName));
            }
        }

        public string NameOfTheGroupsOwner
        {
            // TODO: Fetch owner name from the repository
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.UserId.ToString();
            }
        }

        public string DateOfCreationInStringFormat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.CreatedDate.ToString();
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

        public string AllowanceOfPostageOnTheGroupChat
        {
            get
            {
                return GroupThatIsEncapsulatedByThisInstanceOnViewModel.AllowanceOfPostage == true ? "Yes" : "No";
            }
            set
            {
                GroupThatIsEncapsulatedByThisInstanceOnViewModel.AllowanceOfPostage = value == "Yes";
                OnPropertyChanged(nameof(AllowanceOfPostageOnTheGroupChat));
            }
        }

        public RelayCommand ChangeAllowanceOfPostageCommand => new RelayCommand(execute => ChangeAllowanceOfPostage());

        private void ChangeAllowanceOfPostage()
        {
            AllowanceOfPostageOnTheGroupChat = AllowanceOfPostageOnTheGroupChat == "Yes" ? "No" : "Yes";
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
