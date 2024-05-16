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

        public Guid UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateOnly BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ICollection<MarketplacePost> PostsInCart = new List<MarketplacePost>();

        public ICollection<MarketplacePost> FavoritePosts = new List<MarketplacePost>();
        public ICollection<Group> Groups = new List<Group>();

        public ICollection<MarketplacePost> MarketplacePost = new List<MarketplacePost>();
    }
}
