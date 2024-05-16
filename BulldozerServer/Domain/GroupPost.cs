using System.ComponentModel.DataAnnotations;

namespace BulldozerServer.Domain
{
    public class GroupPost
    {
        private Guid groupPostId;
        private Guid? authorId;
        private Guid groupId;
        private string description;
        private string? mediaContent;
        private DateTime creationDate;
        private bool isPinned;
        private bool adminOnly;

        public GroupPost(Guid groupPostId, Guid? authorId, Guid groupId, string description, string? mediaContent, DateTime creationDate, bool isPinned, bool adminOnly)
        {
            this.groupPostId = groupPostId;
            this.authorId = authorId;
            this.groupId = groupId;
            this.description = description;
            this.mediaContent = mediaContent;
            this.creationDate = creationDate;
            this.isPinned = isPinned;
            this.adminOnly = adminOnly;
        }

        public GroupPost()
        {
            this.groupPostId = Guid.NewGuid();
            this.authorId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
            this.description = Constants.EMPTY_STRING;
            this.mediaContent = Constants.EMPTY_STRING;
            this.creationDate = DateTime.Now;
            this.isPinned = false;
            this.adminOnly = false;
        }

        [Key]
        public Guid GroupPostId { get => groupPostId; }
        public Guid? AuthorId => authorId;

        public Guid GroupId => groupId;

        public string Description { get => description; set => description = value; }

        public string? MediaContent { get => mediaContent; set => mediaContent = value; }

        public DateTime CreationDate => CreationDate;

        public bool IsPinned { get => isPinned; set => isPinned = value; }

        public bool AdminOnly { get => adminOnly; set => adminOnly = value; }

        public User? Author { get; set; }

        public Group Group { get; set; }
    }
}
