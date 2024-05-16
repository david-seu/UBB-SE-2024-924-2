using System.ComponentModel.DataAnnotations;
using ISSLab.Domain.MarketplacePosts;

namespace ISSLab.Domain
{
    public class User
    {
        // GroupMember had description, User does not
        private Guid userId;
        private string username;
        private string fullName;
        private string password;
        private string email;
        private string phoneNumber;
        private DateOnly birthDay;
        private DateTime createdDate;

        public User(Guid userId, string username, string fullName, string password, string email, string phoneNumber, DateOnly birthDay, DateTime createdDate, ICollection<MarketplacePost> postsInCart, ICollection<MarketplacePost> favoritePosts, ICollection<Group> groups, ICollection<MarketplacePost> marketplacePosts)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay;
            CreatedDate = createdDate;
            PostsInCart = postsInCart;
            FavoritePosts = favoritePosts;
            OwnedGroups = groups;
            MarketplacePosts = marketplacePosts;
        }
        public User(Guid userId, string username, string fullName, string password, string email, string phoneNumber)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public User()
        {
            UserId = Guid.Empty;
            Username = Constants.EMPTY_STRING;
            FullName = Constants.EMPTY_STRING;
            Password = Constants.EMPTY_STRING;
            Email = Constants.EMPTY_STRING;
            PhoneNumber = Constants.EMPTY_STRING;
            BirthDay = DateOnly.MinValue;
            CreatedDate = DateTime.MinValue;
        }
        public Guid UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateOnly BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ICollection<MarketplacePost> PostsInCart { get; set; } = new List<MarketplacePost>();

        public ICollection<MarketplacePost> FavoritePosts { get; set; } = new List<MarketplacePost>();
        public ICollection<Group> OwnedGroups { get; } = new List<Group>();

        public ICollection<MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePost>();
        public ICollection<Group> GroupsPartOf { get; } = new List<Group>();
        public ICollection<Membership> Memberships { get; } = new List<Membership>();

        public ICollection<Group> GroupsTryingToJoin { get; } = new List<Group>();
        public ICollection<Request> JoinRequests { get; } = new List<Request>();

        public ICollection<PollOption> SelectedPollOptions { get; } = new List<PollOption>();
        public ICollection<PollAnswer> PollAnswers { get; } = new List<PollAnswer>();
    }
}
