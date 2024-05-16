using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class Cart
    {
        private Guid groupId;
        private Guid userId;
        private Guid marketplacePostId;

        public Guid GroupId { get => groupId; }
        public Guid UserId { get => userId; }
        public Guid MarketplacePostId { get => marketplacePostId; }
    }
}