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
        private Guid userId;
        private Guid marketplacePostId;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid MarketplacePostId { get => marketplacePostId; set => marketplacePostId = value; }
    }
}