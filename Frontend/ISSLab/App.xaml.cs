using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using ISSLab.Domain;
using ISSLab.Services;
using ISSLab.ViewModel;

namespace ISSLab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Guid userId = Guid.NewGuid();
            Guid groupId = Guid.NewGuid();

            DataSet dataSet = new DataSet();

            IChatFactory chatFactory = new ChatFactory();

            // User connectedUser = new User(userId, "Soundboard1", "Dorian", DateOnly.Parse("11.12.2003"), "../Resources/Images/Dorian.jpeg", "fsdgfd", DateTime.Parse("10.04.2024"), new List<Guid>(), new List<Guid>(), new List<Cart>(), new List<UsersFavoritePosts>(), new List<Guid>(), 0);
            // User userOne = new User("Vini", "Vinicius Junior", DateOnly.Parse("11.12.2003"), "../Resources/Images/Vini.png", "fdsfsdfds");
            // User userTwo = new User("DDoorian", "Pop Dorian", DateOnly.Parse("12.12.2003"), "../Resources/Images/Dorian.jpeg", "bcvbc");

            // AddHardcodedUsers(userRepository, connectedUser, userOne, userTwo);
            // AddHardcodedPosts(postRepository, userOne, userTwo, groupId);

            // IPostService postService = new PostService(postRepository);
            // IUserService userService = new UserService(userRepository, postRepository);
            IMainWindowViewModel mainWindowViewModel = new MainWindowViewModel(userId, groupId, chatFactory);
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }

        // private void AddHardcodedUsers(IUserRepository userRepo, User connectedUser, User userOne, User userTwo)
        // {
        //    userRepo.AddUser(connectedUser);
        //    userRepo.AddUser(userOne);
        //    userRepo.AddUser(userTwo);
        // }

        // private void AddHardcodedPosts(IPostRepository postRepository, User userOne, User userTwo, Guid groupId)
        // {
        //    DonationMarketplacePost donationMarketplacePost = new DonationMarketplacePost("../Resources/Images/catei.jpeg", userOne.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", "https://www.unicef.org/romania/ro", Constants.DONATION_POST_TYPE, true);
        //    AuctionMarketplacePost auctionMarketplacePost = new AuctionMarketplacePost("../Resources/Images/catei.jpeg", userOne.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddSeconds(80), "InPerson", Guid.Empty, Guid.Empty, 100, 105, true);
        //    postRepository.AddPost(new FixedPriceMarketplacePost("../Resources/Images/catei.jpeg", userOne.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddMonths(2), "InPerson", Guid.Empty, Constants.FIXED_PRICE_POST_TYPE, true));
        //    FixedPriceMarketplacePost post1 = new FixedPriceMarketplacePost("../Resources/Images/catei.jpeg", userOne.Id, groupId, "Oradea", "A bunch of great dogssdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Dogs", "077333999", 300, DateTime.Now.AddMonths(2), "InPerson", Guid.Empty, Constants.FIXED_PRICE_POST_TYPE, true);
        //    postRepository.AddPost(post1);
        //    postRepository.AddPost(new FixedPriceMarketplacePost("../Resources/Images/catei.jpeg", userTwo.Id, groupId, "Bistrita", "Some great dogs", "Something else", "0222111333", 350, DateTime.Now.AddDays(6), "shipping", Guid.Empty, Constants.FIXED_PRICE_POST_TYPE, true));
        //    postRepository.AddPost(donationMarketplacePost);
        //    postRepository.AddPost(auctionMarketplacePost);
        // }
    }
}
