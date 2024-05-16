using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class PollOption
    {
        private Guid pollOptionId;
        private Guid pollId;
        private string option;

        public PollOption(Guid pollId, string option)
        {
            this.pollOptionId = Guid.NewGuid();
            this.pollId = pollId;
            this.option = option;
        }

        public PollOption()
        {
            this.pollOptionId = Guid.NewGuid();
            this.pollId = Guid.NewGuid();
            this.option = Constants.EMPTY_STRING;
        }

        public PollOption(Guid pollOptionId, Guid pollId, string option)
        {
            this.pollOptionId = pollOptionId;
            this.pollId = pollId;
            this.option = option;
        }

        public Guid PollOptionId { get => pollOptionId; }
        public Guid PollId { get => pollId; }
        public string Option { get => option; set => option = value; }
    }
}
