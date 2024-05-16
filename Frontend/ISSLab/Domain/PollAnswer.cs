using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Domain
{
    public class PollAnswer
    {
        private Guid pollOptionId;
        private Guid userId;

        public PollAnswer(Guid userId)
        {
            this.pollOptionId = Guid.NewGuid();
            this.userId = userId;
        }

        public PollAnswer()
        {
            this.pollOptionId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
        }

        public PollAnswer(Guid pollAnswerId, Guid userId)
        {
            this.pollOptionId = pollAnswerId;
            this.userId = userId;
        }

        public Guid PollOptionId { get => pollOptionId; }
        public Guid UserId { get => userId; }

        public User UserThatAnswered { get; set; }

        public PollOption PollOption { get; set; }
    }

}
