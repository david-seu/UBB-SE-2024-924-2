using System.ComponentModel.DataAnnotations;
using BulldozerServer.Domain.MarketplacePosts;

namespace BulldozerServer.Domain
{
    public class User
    {
        private Guid userId;
        private string username;
        private string fullName;
        private string password;
        private string email;
        private string phoneNumber;
        private DateOnly birthDay;
        private DateTime createdDate;

        // create public properties for each field
        [Key]
        public Guid UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateOnly BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ICollection<MarketplacePost> PostsInCart { get; } = new List<MarketplacePost>();

        public ICollection<MarketplacePost> FavoritePosts { get; } = new List<MarketplacePost>();
        public ICollection<Group> OwnedGroups { get; } = new List<Group>();

        public ICollection<MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePost>();

        public ICollection<Group> GroupsPartOf { get; } = new List<Group>();
        public ICollection<Membership> Memberships { get; } = new List<Membership>();

        public ICollection<Group> GroupsTryingToJoin { get; } = new List<Group>();
        public ICollection<JoinRequest> JoinRequests { get; } = new List<JoinRequest>();

        public ICollection<PollOption> SelectedPollOptions { get; } = new List<PollOption>();
        public ICollection<PollAnswer> PollAnswers { get; } = new List<PollAnswer>();
        public ICollection<GroupPost> GroupPosts { get; } = new List<GroupPost>();
    }
}
