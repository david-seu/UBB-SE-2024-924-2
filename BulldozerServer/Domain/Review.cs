using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class Review
    {
        private Guid reviewId;
        private Guid userId;
        private Guid marketplacePostId;
        private string content;
        private int rating;
        private DateOnly postTime;

        public Review(Guid userId, Guid marketplacePostId, string content, int rating, DateOnly postTime)
        {
            this.userId = userId;
            this.marketplacePostId = marketplacePostId;
            this.content = content;
            this.rating = rating;
            this.postTime = postTime;
        }

        public Review()
        {
            this.userId = Guid.NewGuid();
            this.marketplacePostId = Guid.NewGuid();
            this.content = Constants.EMPTY_STRING;
            this.rating = 0;
            this.postTime = DateOnly.FromDateTime(DateTime.Now);
        }

        public Review(Guid userId, Guid marketplacePostId)
        {

        }

    }
}
