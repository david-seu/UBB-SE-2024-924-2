namespace ISSLab.Domain
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

        public Guid GroupId { get => groupId; set => groupId = value; }
        public Guid OwnerId { get => ownerId; set => ownerId = value; }

        public string GroupName { get => groupName; set => groupName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public bool AllowanceOfPostage { get => allowanceOfPostage; set => allowanceOfPostage = value; }
        public Group(Guid groupId, Guid ownerId, string groupName, string groupDescription, bool isPublic, bool allowanceOfPostage)
        {
            GroupId = groupId;
            OwnerId = ownerId;
            GroupName = groupName;
            Description = groupDescription;
            IsPublic = isPublic;
            AllowanceOfPostage = allowanceOfPostage;
        }

        public Group()
        {
        }
    }
}
