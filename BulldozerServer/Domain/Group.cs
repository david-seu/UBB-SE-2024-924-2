namespace BulldozerServer.Domain
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

        public Group(Guid groupId, Guid userId, string groupName, string description, DateTime createdDate, bool isPublic, bool allowanceOfPostage)
        {
            this.groupId = groupId;
            this.userId = userId;
            this.groupName = groupName;
            this.description = description;
            this.createdDate = createdDate;
            this.isPublic = isPublic;
            this.allowanceOfPostage = allowanceOfPostage;
        }

        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid UserId { get => userId; set => userId = value; }

        public User User { get; set; } = null!;
        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
        public ICollection<MarketplacePosts.MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePosts.MarketplacePost>();
    }
}
