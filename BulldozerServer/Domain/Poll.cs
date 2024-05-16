using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class Poll
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

        public Poll(string description, DateOnly creationDate, DateOnly endDate, bool isPinned, bool isVisible,
            bool isMultipleChoice, bool isAnonymous)
        {
            this.pollId = Guid.NewGuid();
            this.description = description;
            this.creationDate = creationDate;
            this.endDate = endDate;
            this.isPinned = isPinned;
            this.isVisible = isVisible;
            this.isMultipleChoice = isMultipleChoice;
            this.isAnonymous = isAnonymous;
        }

        public Poll()
        {
            this.pollId = Guid.NewGuid();
            this.description = Constants.EMPTY_STRING;
            this.creationDate = DateOnly.FromDateTime(DateTime.Now);
            this.endDate = DateOnly.FromDateTime(DateTime.Now);
            this.isPinned = false;
            this.isVisible = false;
            this.isMultipleChoice = false;
            this.isAnonymous = false;
        }

        public Poll(Guid pollId, string description, DateOnly creationDate, DateOnly endDate, bool isPinned,
            bool isVisible,
            bool isMultipleChoice, bool isAnonymous)
        {
            this.pollId = pollId;
            this.description = description;
            this.creationDate = creationDate;
            this.endDate = endDate;
            this.isPinned = isPinned;
            this.isVisible = isVisible;
            this.isMultipleChoice = isMultipleChoice;
            this.isAnonymous = isAnonymous;
        }

        public Guid PollId { get => pollId; }
        public Guid GroupId { get => groupId; }
        public string Description { get => description; set => description = value; }
        public DateOnly CreationDate { get => creationDate; }
        public DateOnly EndDate { get => endDate; set => endDate = value; }
        public bool IsPinned { get => isPinned; set => isPinned = value; }
        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public bool IsMultipleChoice { get => isMultipleChoice; set => isMultipleChoice = value; }
        public bool IsAnonymous { get => isAnonymous; set => isAnonymous = value; }
    }
}
