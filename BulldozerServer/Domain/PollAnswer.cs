using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class PollAnswer
    {
        private Guid pollAnswerId;
        private Guid userId;

        public PollAnswer(Guid userId)
        {
            this.pollAnswerId = Guid.NewGuid();
            this.userId = userId;
        }

        public PollAnswer()
        {
            this.pollAnswerId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
        }

        public PollAnswer(Guid pollAnswerId, Guid userId)
        {
            this.pollAnswerId = pollAnswerId;
            this.userId = userId;
        }

    }
}
