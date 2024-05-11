using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class SellingUserScore
    {
        private int score;
        private Guid userId;
        private Guid groupId;

        public SellingUserScore(Guid userId, Guid groupId)
        {
            this.userId = userId;
            this.groupId = groupId;
            score = 0;
        }

        public SellingUserScore()
        {
            userId = Guid.NewGuid();
            groupId = Guid.NewGuid();
            score = 0;
        }

        public SellingUserScore(Guid userId, Guid groupId, int score)
        {
            this.userId = userId;
            this.groupId = groupId;
            this.score = score;
        }

        public Guid UserId { get => userId; }
        public Guid GroupId { get => groupId; }
        public int Score { get => score; set => score = value; }
    }
}
