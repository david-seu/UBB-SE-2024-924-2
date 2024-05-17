namespace ISSLab.Domain
{
    public class GroupPost
    {
        private Guid groupPostId;
        private Guid? authorId;
        private Guid groupId;
        private string? mediaContent;
        private DateTime creationDate;
        private string postImage;
        private bool isPinned;
        private bool adminOnly;
        public Guid GroupPostId { get => groupPostId; set => groupPostId = value; }
        public Guid? AuthorId { get => authorId; set => authorId = value; }

        public string PostImage
        {
            get => postImage; set => postImage = value;
        }
        public Guid GroupId { get => groupId; set => groupId = value; }

        public string? PostContent { get => mediaContent; set => mediaContent = value; }

        public DateTime CreationDate { get => creationDate; set => creationDate = value; }

        public bool IsPinned { get => isPinned; set => isPinned = value; }

        public bool AdminOnly { get => adminOnly; set => adminOnly = value; }

        public GroupPost(Guid groupPostId, Guid? authorId, Guid groupId, string? mediaContent, DateTime creationDate, string postImage, bool isPinned, bool adminOnly)
        {
            GroupPostId = groupPostId;
            AuthorId = authorId;
            GroupId = groupId;
            PostContent = mediaContent;
            CreationDate = creationDate;
            PostImage = postImage;
            IsPinned = isPinned;
            AdminOnly = adminOnly;
        }

        public GroupPost()
        {
        }
    }
}
