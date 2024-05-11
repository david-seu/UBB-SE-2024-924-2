using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model.Entities
{
    public class MarketplacePost
    {
        private Guid id;
        private int views;
        private List<Guid> usersThatShared;
        private List<Guid> usersThatLiked;
        private string mediaContent;
        private DateTime creationDate;
        private Guid authorId;
        private Guid groupId;
        private bool promoted;
        private List<Guid> usersThatFavorited;
        private string itemLocation;
        private bool confirmed;
        private string description;
        private string title;
        private List<InterestStatus> interestStatuses;
        private string contacts;
        private string type;

        public MarketplacePost(string mediaContent, Guid authorId, Guid groupId, string itemLocation, string description, string title, string contacts, string type, bool confirmed)
        {
            this.confirmed = confirmed;
            id = Guid.NewGuid();
            usersThatShared = new List<Guid>();
            usersThatLiked = new List<Guid>();
            this.mediaContent = mediaContent;
            creationDate = DateTime.Now;
            this.authorId = authorId;
            this.groupId = groupId;
            promoted = false;
            usersThatFavorited = new List<Guid>();
            this.itemLocation = itemLocation;
            this.description = description;
            this.title = title;
            views = 0;
            interestStatuses = new List<InterestStatus>();
            this.contacts = contacts;
            this.type = type;
        }

        public MarketplacePost(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, string mediaContent, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string itemLocation, string description, string title, List<InterestStatus> interestStatuses, string contacts, string type, bool confirmed, int views)
        {
            this.id = id;
            this.usersThatShared = usersThatShared;
            this.usersThatLiked = usersThatLiked;
            this.mediaContent = mediaContent;
            this.creationDate = creationDate;
            this.authorId = authorId;
            this.groupId = groupId;
            this.promoted = promoted;
            this.usersThatFavorited = usersThatFavorited;
            this.itemLocation = itemLocation;
            this.description = description;
            this.title = title;
            this.interestStatuses = interestStatuses;
            this.contacts = contacts;
            this.type = type;
            this.views = views;
            this.confirmed = confirmed;
        }

        public MarketplacePost()
        {
            id = Guid.NewGuid();
            usersThatShared = new List<Guid>();
            usersThatLiked = new List<Guid>();
            mediaContent = Constants.EMPTY_STRING;
            creationDate = DateTime.Now;
            authorId = Guid.NewGuid();
            groupId = Guid.NewGuid();
            promoted = false;
            usersThatFavorited = new List<Guid>();
            itemLocation = Constants.EMPTY_STRING;
            description = Constants.EMPTY_STRING;
            title = Constants.EMPTY_STRING;
            interestStatuses = new List<InterestStatus>();
            contacts = Constants.EMPTY_STRING;
            type = Constants.DEFAULT_POST_TYPE;
            confirmed = false;
        }

        public int Views { get => views; set => views = value; }
        public string Type { get => type; set => type = value; }

        public Guid Id { get => id; }
        public List<Guid> UsersThatShared { get => usersThatShared; }
        public List<Guid> UsersThatLiked { get => usersThatLiked; }
        public string MediaContent { get => mediaContent; set => mediaContent = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public Guid AuthorId { get => authorId; }
        public Guid GroupId { get => groupId; }
        public bool Promoted { get => promoted; set => promoted = value; }
        public List<Guid> UsersThatFavorited { get => usersThatFavorited; }
        public string ItemLocation { get => itemLocation; set => itemLocation = value; }
        public string Description { get => description; set => description = value; }
        public string Title { get => title; set => title = value; }
        public List<InterestStatus> InterestStatuses { get => interestStatuses; }
        public string Contacts { get => contacts; set => contacts = value; }

        public bool Confirmed { get => confirmed; set => confirmed = value; }

        public void ToggleFavorite(Guid userId)
        {
            if (usersThatFavorited.Contains(userId))
            {
                usersThatFavorited.Remove(userId);
            }
            else
            {
                usersThatFavorited.Add(userId);
            }
        }

        public void ToggleLike(Guid userId)
        {
            if (usersThatLiked.Contains(userId))
            {
                usersThatLiked.Remove(userId);
            }
            else
            {
                usersThatLiked.Add(userId);
            }
        }

        public void ToggleShare(Guid userId)
        {
            if (usersThatShared.Contains(userId))
            {
                usersThatShared.Remove(userId);
            }
            else
            {
                usersThatShared.Add(userId);
            }
        }

        public int InterestLevel()
        {
            return interestStatuses.FindAll(checkedInterestStatus => checkedInterestStatus.Interested).Count
                - interestStatuses.FindAll(checkedInterestStatus => !checkedInterestStatus.Interested).Count;
        }

        public void AddInterestStatus(InterestStatus interestStatus)
        {
            interestStatuses.Add(interestStatus);
        }

        public void RemoveInterestStatus(Guid userId)
        {
            interestStatuses.RemoveAll(checkedInterestStatus => checkedInterestStatus.InterestedUserId == userId);
        }
        public void ToggleInterestStatus(Guid userId)
        {
            int indexOfUsersInterestStatus = interestStatuses.FindIndex(checkedInterestStatus => checkedInterestStatus.InterestedUserId == userId);
            if (indexOfUsersInterestStatus == -1)
            {
                throw new Exception("Interest status not found");
            }
            else
            {
                interestStatuses[indexOfUsersInterestStatus].ToggleInterested();
            }
        }
    }
}
