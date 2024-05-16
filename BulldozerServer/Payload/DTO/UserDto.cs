using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Domain;
namespace BulldozerServer.Payload.DTO
{
    public class UserDto
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
        public ICollection<Group> OwnedGroups { get; set; } = new List<Group>();

        public ICollection<MarketplacePost> MarketplacePosts { get; set; } = new List<MarketplacePost>();

        public ICollection<Group> GroupsPartOf { get; set; } = new List<Group>();
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();

        public ICollection<Group> GroupsTryingToJoin { get; set; } = new List<Group>();
        public ICollection<JoinRequest> JoinRequests { get; set; } = new List<JoinRequest>();

        public ICollection<PollOption> SelectedPollOptions { get; set; } = new List<PollOption>();
        public ICollection<PollAnswer> PollAnswers { get; set; } = new List<PollAnswer>();
        public ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();
    }
}
