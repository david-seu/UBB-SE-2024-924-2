using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace ISSLab.Domain
{
    public class Poll
    {
        private Guid pollId;
        private Guid userId;
        private Guid groupId;
        private string description;
        private DateOnly creationDate;
        private DateOnly endDate;
        private bool isPinned;
        private bool isVisible;
        private bool isMultipleChoice;
        private bool isAnonymous;
        private List<Vote> votes;

        [Key]
        public Guid PollId { get => pollId; }
        public Guid OwnerId { get => userId; }
        public Guid GroupId { get => groupId; }
        public string Description { get => description; set => description = value; }
        public DateOnly CreationDate { get => creationDate; }
        public DateOnly EndDate { get => endDate; set => endDate = value; }
        public bool IsPinned { get => isPinned; set => isPinned = value; }
        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public bool IsMultipleChoice { get => isMultipleChoice; set => isMultipleChoice = value; }
        public bool IsAnonymous { get => isAnonymous; set => isAnonymous = value; }

        public Group Group { get; }

        public ICollection<PollOption> PollOptions { get; } = new List<PollOption>();

        public List<Vote> Votes { get => votes; set => votes = value; }

        public Poll(Guid id, Guid ownerId, string description, Guid groupId)
        {
            this.groupId = groupId;
            this.pollId = id;
            this.userId = ownerId;
            this.description = description;

            this.isVisible = true;
            this.IsMultipleChoice = true;
            this.IsAnonymous = false;

            Votes = new List<Vote>();
        }

        public Vote GetVote(Guid voteId)
        {
            Vote vote = Votes.First(vote => vote.Id == voteId);
            if (vote == null)
            {
                throw new Exception("Vote not found");
            }
            return vote;
        }

        public void AddVote(Vote vote)
        {
            Votes.Add(vote);
        }

        public void RemoveVote(Guid voteId)
        {
            Vote vote = Votes.First(vote => vote.Id == voteId);
            if (vote == null)
            {
                throw new Exception("Vote not found");
            }
            Votes.Remove(vote);
        }
    }
}
