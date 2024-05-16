using ISSLab.Model.Entities;

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
        private string groupCode;
        private int memberCount = 0;
        private List<Post> postList = new List<Post>();
        private int maxPostsPerHourPerUser;
        private bool canMakePostsByDefault;
        private string icon;
        private string banner;

        public bool CanMakePostsByDefault { get => canMakePostsByDefault; set => canMakePostsByDefault = value; }
        public string Icon { get => icon; set => icon = value; }
        public string Banner { get => banner; set => banner = value; }
        public int MaxPostsPerHourPerUser { get => maxPostsPerHourPerUser; set => maxPostsPerHourPerUser = value; }
        public List<Post> Posts { get => postList; set => postList = value; }

        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid UserId { get => userId; set => userId = value; }

        public User User { get; set; } = null!;
        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }

        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
        public string GroupCode { get => groupCode; set => groupCode = value; }
        public int MemberCount { get => memberCount; set => memberCount = value; }
        public ICollection<MarketplacePosts.MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePosts.MarketplacePost>();
    }
}
