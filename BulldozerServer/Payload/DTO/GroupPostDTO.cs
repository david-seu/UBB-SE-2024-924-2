using BulldozerServer.Domain;

namespace BulldozerServer.Payload.DTO
{
    public class GroupPostDTO
    {
        private Guid groupPostId;
        private Guid? authorId;
        private Guid groupId;
        private string description;
        private string? mediaContent;
        private DateTime creationDate;
        private string postImage;
        private bool isPinned;
        private bool adminOnly;
        public Guid GroupPostId { get => groupPostId; }
        public Guid? AuthorId => authorId;

        public string PostImage
        {
            get => postImage;
        }
        public Guid GroupId => groupId;

        public string Description { get => description; set => description = value; }

        public string? PostContent { get => mediaContent; set => mediaContent = value; }

        public DateTime CreationDate => CreationDate;

        public bool IsPinned { get => isPinned; set => isPinned = value; }

        public bool AdminOnly { get => adminOnly; set => adminOnly = value; }

        public User? Author { get; set; }

        public Group Group { get; set; }
    }
}
