using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class UsersFavoritePosts
    {
        private Guid userId;
        private Guid groupId;
        private List<Guid> posts;

        public UsersFavoritePosts(Guid userId, Guid groupId)
        {
            this.userId = userId;
            this.groupId = groupId;
            posts = new List<Guid>();
        }

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
        public Guid GroupId { get => groupId; }
        public List<Guid> Posts { get => posts; }

        public void AddPost(Guid post)
        {
            if (posts.Contains(post))
            {
                throw new Exception("MarketplacePost already in favorites");
            }
            posts.Add(post);
        }

        public void RemovePost(Guid post)
        {
            if (!posts.Contains(post))
            {
                throw new Exception("MarketplacePost not in favorites");
            }
            posts.Remove(post);
        }
    }
}
