using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class UsersFavoritePosts
    {
        private Guid userId;
        private Guid marketplacePostId;

        public UsersFavoritePosts(Guid userId, Guid groupId, List<Guid> posts)
        {
            this.userId = userId;
            this.groupId = groupId;
            this.posts = posts;
        }

        public UsersFavoritePosts()
        {
            userId = Guid.NewGuid();
            groupId = Guid.NewGuid();
            posts = new List<Guid>();
        }

        public Guid UserId { get => userId; }
        public Guid MarketplacePostId { get => marketplacePostId; }
    }
}
