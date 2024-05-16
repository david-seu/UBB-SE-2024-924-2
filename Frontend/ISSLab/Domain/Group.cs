namespace ISSLab.Domain
{
    public class Group
    {
        private Guid groupId;
        private Guid userId;
        private string groupName;
        private string description;
        private DateTime createdDate;
        private bool isPublic;
        private bool allowanceOfPostage;

        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid UserId { get => userId; set => userId = value; }

        public User User { get; set; } = null!;
        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
        public ICollection<MarketplacePosts.MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePosts.MarketplacePost>();
        public ICollection<User> Users { get; } = new List<User>();
        public ICollection<Membership> Memberships { get; } = new List<Membership>();
        public ICollection<User> UsersTryingToJoin { get; } = new List<User>();
        public ICollection<Request> JoinRequests { get; } = new List<Request>();

        public ICollection<Poll> GroupPolls { get; } = new List<Poll>();
    }
}
