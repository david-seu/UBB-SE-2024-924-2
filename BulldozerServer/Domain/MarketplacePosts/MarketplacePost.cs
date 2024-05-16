using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulldozerServer.Domain.MarketplacePosts
{
    public class MarketplacePost
    {
        private Guid marketplacePostId;
        private Guid? authorId;
        private Guid groupId;
        private string title;
        private string description;
        private string? mediaContent;
        private string? location;
        private DateTime creationDate;
        private DateTime? endDate;
        private bool isPromoted;
        private bool isActive;

        [Key]
        public Guid MarketplacePostId { get => marketplacePostId; set => marketplacePostId = value; }

        [AllowNull]
        public Guid? AuthorId { get => authorId; set => authorId = value; }
        public Guid GroupId { get => groupId; set => groupId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        [AllowNull]
        public string? MediaContent { get => mediaContent; set => mediaContent = value; }
        [AllowNull]
        public string? Location { get => location; set => location = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        [AllowNull]
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public bool IsPromoted { get => isPromoted; set => isPromoted = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public User? Author { get; set; }

        public Group Group { get; set; }

        public ICollection<User> PeopleThatFavored { get; } = new List<User>();

        public ICollection<User> PeopleThatPlacedInCart { get; } = new List<User>();

        public MarketplacePost(Guid marketplacePostId, Guid authorId, Guid groupId, string title, string description, string mediaContent,
            string location, DateTime creationDate, DateTime? endDate, bool isPromoted, bool isActive)
        {
            this.marketplacePostId = marketplacePostId;
            this.authorId = authorId;
            this.groupId = groupId;
            this.title = title;
            this.description = description;
            this.mediaContent = mediaContent;
            this.location = location;
            this.creationDate = creationDate;
            this.endDate = endDate;
            this.isPromoted = isPromoted;
            this.isActive = isActive;
        }

        public MarketplacePost()
        {
            this.marketplacePostId = Guid.NewGuid();
            this.authorId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
            this.title = Constants.EMPTY_STRING;
            this.description = Constants.EMPTY_STRING;
            this.mediaContent = Constants.EMPTY_STRING;
            this.location = Constants.EMPTY_STRING;
            this.creationDate = DateTime.Now;
            this.endDate = null;
            this.isPromoted = false;
            this.isActive = true;
        }
    }
}
