using BulldozerServer.Domain;

namespace BulldozerServer.Payload.DTO
{
    public class PollDTO
    {
        private Guid pollId;
        private Guid groupId;
        private string description;
        private DateOnly creationDate;
        private DateOnly endDate;
        private bool isPinned;
        private bool isVisible;
        private bool isMultipleChoice;
        private bool isAnonymous;
        public Guid PollId { get => pollId; set => pollId = value; }
        public Guid GroupId { get => groupId; set => groupId = value; }
        public string Description { get => description; set => description = value; }
        public DateOnly CreationDate { get => creationDate; set => creationDate = value; }
        public DateOnly EndDate { get => endDate; set => endDate = value; }
        public bool IsPinned { get => isPinned; set => isPinned = value; }
        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public bool IsMultipleChoice { get => isMultipleChoice; set => isMultipleChoice = value; }
        public bool IsAnonymous { get => isAnonymous; set => isAnonymous = value; }

        public Group Group { get; }

        public ICollection<PollOption> PollOptions { get; } = new List<PollOption>();
    }
}
