﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ISSLab.Domain;
using ISSLab.Domain.MarketplacePosts;
using ISSLab.Services;
using ISSLab.View;

namespace ISSLab.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        // private IPostService postService;
        // private IUserService userService;
        private ObservableCollection<IPostContentViewModel> shownPosts;
        private Guid userId;
        private Guid groupId;
        private ICreatePostViewModel postCreationViewModel;
        private IChatFactory chatFactory;

        public MainWindowViewModel(Guid userId, Guid groupId, IChatFactory chatFactory)
        {
            // this.postService = givenPostService;
            // this.userService = givenUserService;
            this.userId = userId;
            this.groupId = groupId;
            this.chatFactory = chatFactory;

            shownPosts = new ObservableCollection<IPostContentViewModel>();

            postCreationViewModel = new CreatePostViewModel(userId, groupId);

            // LoadPostsCommand(postService.GetPosts());
            ChangeToMarketPlace();
        }

        public ICreatePostViewModel PostCreationViewModel
        {
            get
            {
                return postCreationViewModel;
            }
            set
            {
                postCreationViewModel = value;
                OnPropertyChanged(nameof(PostCreationViewModel));
            }
        }

        public ObservableCollection<IPostContentViewModel> ShownPosts
        {
            get
            {
                return shownPosts;
            }
            set
            {
                shownPosts = value;
                OnPropertyChanged(nameof(ShownPosts));
            }
        }

        public Guid IdOfActiveUser { get; set; }

        public async void ChangeToFavorites()
        {
            ApiService apiService = ApiService.Instance;
            try
            {
                List<MarketplacePost> favoritedPosts = await apiService.GetFavouritePosts(this.userId);
                LoadPostsCommand(favoritedPosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the posts to favorite: {ex.Message}");
            }
        }

        public async void ChangeToMarketPlace()
        {
            ApiService apiService = ApiService.Instance;
            try
            {
                List<MarketplacePost> posts = await apiService.GetMarketplacePosts();
                LoadPostsCommand(posts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the posts to marketplace: {ex.Message}");
            }
        }

        public async void ChangeToCart()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<MarketplacePost> cart = await apiService.GetPostsFromCart(userId);
                Console.WriteLine($"Successfully fetched the posts in the cart");

                LoadPostsCommand(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the posts in the cart: {ex.Message}");
            }
        }

        public async void LoadPostsCommand(List<MarketplacePost> postsToLoad)
        {
            ApiService apiService = ApiService.Instance;
            shownPosts.Clear();
            foreach (MarketplacePost currentPostToLoad in postsToLoad)
            {
                try
                {
                    User reveivedUser = await apiService.GetUserById(currentPostToLoad.AuthorId.Value);
                    shownPosts.Add(new PostContentViewModel(currentPostToLoad, reveivedUser, this.userId, this.groupId, this.chatFactory));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while fetching the posts in the cart: {ex.Message}");
                }
            }

            // OnPropertyChanged(nameof(ShownPosts));
        }

        // main window view model from the other project
        public ObservableCollection<Group> CollectionOfActiveGroups { get; set; }

        public MainWindowViewModel()
        {
            // string connection = "your connection string goes here";
            // SqlConnection sqlConnection = new SqlConnection(connection);
            // GroupMemberRepository groupMemberRepository = new GroupMemberRepository(sqlConnection);
            // GroupRepository groupRepository = new GroupRepository(sqlConnection);
            // GroupMembershipRepository groupMembershipRepository = new GroupMembershipRepository(sqlConnection);
            // RequestsRepository requestsRepository = new RequestsRepository(sqlConnection);
            Guid idOfCurrentMockUser = new Guid("44d5aa9a-b0f4-4e36-a21e-bdc33b97b5a5");
            IdOfActiveUser = idOfCurrentMockUser;
            User mockGroupMember = new User(idOfCurrentMockUser, "Dorian", "admin", "dorian@ubb.ro", "0725702312", "No paper, no pencil but I am still drawing attention.");
            CurrentActiveUser = mockGroupMember;
            CollectionOfActiveGroups = new ObservableCollection<Group>();

            // CollectionOfActiveGroups = new ObservableCollection<Group>
            // {
            //    // new Group(, Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true),
            //    // new Group(Guid.NewGuid(), Guid.NewGuid(), "Group 1", "Description 1",  true, true)
            //    //// groups created with the Renewals GroupMarketplace entity
            //    // new GroupMarketplace("name1", "description1", "type1", "path1"),
            //    // new GroupMarketplace("name1", "description1", "type1", "path1"),
            //    // new GroupMarketplace("name1", "description1", "type1", "path1"),
            //    // new GroupMarketplace("name1", "description1", "type1", "path1"),
            //    // new GroupMarketplace("name1", "description1", "type1", "path1"),
            // };
           FetchGroups();
        }

        public async void FetchGroups()
        {
            ApiService apiService = ApiService.Instance;

            try
            {
                List<Group> groups = await apiService.GetGroupsAsync();
                Console.WriteLine($"Successfully fetched the groups");

                CollectionOfActiveGroups.Clear();
                foreach (Group currentGroup in groups)
                {
                    CollectionOfActiveGroups.Add(currentGroup);
                }
                CurrentlySelectedGroupMarketplace = CollectionOfActiveGroups[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching the group POSTS: {ex.Message}");
            }
        }

        private User currentActiveUser;

        public User CurrentActiveUser
        {
            get
            {
                return this.currentActiveUser;
            }
            set
            {
                this.currentActiveUser = value;
                OnPropertyChanged(nameof(CurrentActiveUser));
            }
        }

        private Group currentlySelectedGroupMarketplace;
        public Group CurrentlySelectedGroupMarketplace
        {
            get
            {
                return this.currentlySelectedGroupMarketplace;
            }
            set
            {
                this.currentlySelectedGroupMarketplace = value;
                OnPropertyChanged(nameof(CurrentlySelectedGroupMarketplace));
            }
        }

        public Guid UserId
        {
            get
            {
                return userId;
            }
        }

        public Guid GroupId
        {
            get
            {
                return groupId;
            }
        }

        private GroupViewModel viewModelCorrespondingToTheCurrentlySelectedGroup;
        public GroupViewModel ViewModelCorrespondingToTheCurrentlySelectedGroup
        {
            get
            {
                return this.viewModelCorrespondingToTheCurrentlySelectedGroup;
            }
            set
            {
                this.viewModelCorrespondingToTheCurrentlySelectedGroup = value;
                OnPropertyChanged(nameof(ViewModelCorrespondingToTheCurrentlySelectedGroup));
            }
        }
    }
}
