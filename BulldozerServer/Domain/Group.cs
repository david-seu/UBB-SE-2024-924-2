using System.Diagnostics.Contracts;

namespace BulldozerServer.Domain
{
    public class Group
    {
        private Guid groupId;
        private Guid ownerId;
        private string groupName;
        private string description;
        private DateTime createdDate;
        private bool isPublic;
        private bool allowanceOfPostage;

        public Group(Guid groupId, Guid ownerId, string groupName, string description, DateTime createdDate, bool isPublic, bool allowanceOfPostage)
        {
            this.groupId = groupId;
            this.ownerId = ownerId;
            this.groupName = groupName;
            this.description = description;
            this.createdDate = createdDate;
            this.isPublic = isPublic;
            this.allowanceOfPostage = allowanceOfPostage;
        }

        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid OwnerId { get => ownerId; set => ownerId = value; }

        public User Owner { get; set; } = null!;
        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
        public ICollection<MarketplacePosts.MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePosts.MarketplacePost>();

        public ICollection<User> Users { get; } = new List<User>();
        public ICollection<Membership> Memberships { get; } = new List<Membership>();
        public ICollection<User> UsersTryingToJoin { get; } = new List<User>();
        public ICollection<JoinRequest> JoinRequests { get; } = new List<JoinRequest>();

        public ICollection<Poll> GroupPolls { get; } = new List<Poll>();

        public ICollection<GroupPost> GroupPosts { get; } = new List<GroupPost>();
    }
}
