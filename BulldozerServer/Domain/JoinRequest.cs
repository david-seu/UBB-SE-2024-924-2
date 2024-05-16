using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class JoinRequest
    {
        private Guid joinRequestId;
        private Guid userId;
        private Guid groupId;

        public JoinRequest(Guid userId, Guid groupId)
        {
            this.joinRequestId = Guid.NewGuid();
            this.userId = userId;
            this.groupId = groupId;
        }

        public JoinRequest()
        {
            this.userId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
        }

        public JoinRequest(Guid joinRequestId, Guid userId, Guid groupId)
        {
            this.joinRequestId = joinRequestId;
            this.userId = userId;
            this.groupId = groupId;
        }

        public Guid JoinRequestId { get => joinRequestId; }
        public Guid UserId { get => userId; }
        public Guid GroupId { get => groupId; }
    }
}
