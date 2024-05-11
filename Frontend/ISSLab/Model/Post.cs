﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    public class Post
    {
        private Guid id;
        private int views;
        private List<Guid> usersThatShared;
        private List<Guid> usersThatLiked;
        private List<Comment> comments;
        private string mediaContent;
        private DateTime creationDate;
        private Guid authorId;
        private Guid groupId;
        private bool promoted;
        private List<Guid> usersThatFavorited;
        private List<Report> reports;
        private string itemLocation;
        private bool confirmed;
        private string description;
        private string title;
        private List<InterestStatus> interestStatuses;
        private string contacts;
        private string type;

        public Post(string mediaContent, Guid authorId, Guid groupId, string itemLocation, string description, string title, string contacts, string type, bool confirmed)
        {
            this.confirmed = confirmed;
            this.id = Guid.NewGuid();
            this.usersThatShared = new List<Guid>();
            this.usersThatLiked = new List<Guid>();
            this.comments = new List<Comment>();
            this.mediaContent = mediaContent;
            this.creationDate = DateTime.Now;
            this.authorId = authorId;
            this.groupId = groupId;
            this.promoted = false;
            this.usersThatFavorited = new List<Guid>();
            this.itemLocation = itemLocation;
            this.description = description;
            this.title = title;
            this.views = 0;
            this.interestStatuses = new List<InterestStatus>();
            this.contacts = contacts;
            this.reports = new List<Report>();
            this.type = type;
        }

        public Post(Guid id, List<Guid> usersThatShared, List<Guid> usersThatLiked, List<Comment> comments, string mediaContent, DateTime creationDate, Guid authorId, Guid groupId, bool promoted, List<Guid> usersThatFavorited, string itemLocation, string description, string title, List<InterestStatus> interestStatuses, string contacts, List<Report> reports, string type, bool confirmed, int views)
        {
            this.id = id;
            this.usersThatShared = usersThatShared;
            this.usersThatLiked = usersThatLiked;
            this.comments = comments;
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
            this.reports = reports;
            this.type = type;
            this.views = views;
            this.confirmed = confirmed;
        }

        public Post()
        {
            this.id = Guid.NewGuid();
            this.usersThatShared = new List<Guid>();
            this.usersThatLiked = new List<Guid>();
            this.comments = new List<Comment>();
            this.reports = new List<Report>();
            this.mediaContent = Constants.EMPTY_STRING;
            this.creationDate = DateTime.Now;
            this.authorId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
            this.promoted = false;
            this.usersThatFavorited = new List<Guid>();
            this.itemLocation = Constants.EMPTY_STRING;
            this.description = Constants.EMPTY_STRING;
            this.title = Constants.EMPTY_STRING;
            this.interestStatuses = new List<InterestStatus>();
            this.contacts = Constants.EMPTY_STRING;
            this.type = Constants.DEFAULT_POST_TYPE;
            this.confirmed = false;
        }

        public int Views { get => views; set => views = value; }
        public string Type { get => type; set => type = value; }

        public Guid Id { get => id; }
        public List<Guid> UsersThatShared { get => usersThatShared; }
        public List<Guid> UsersThatLiked { get => usersThatLiked; }
        public List<Comment> Comments { get => comments; }
        public string MediaContent { get => mediaContent; set => mediaContent = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public Guid AuthorId { get => authorId; }
        public Guid GroupId { get => groupId; }
        public bool Promoted { get => promoted; set => promoted = value; }
        public List<Guid> UsersThatFavorited { get => usersThatFavorited; }
        public List<Report> Reports { get => reports; }
        public string ItemLocation { get => itemLocation; set => itemLocation = value; }
        public string Description { get => description; set => description = value; }
        public string Title { get => title; set => title = value; }
        public List<InterestStatus> InterestStatuses { get => interestStatuses; }
        public string Contacts { get => contacts; set => contacts = value; }

        public bool Confirmed { get => confirmed; set => confirmed = value; }

        public void AddReport(Report report)
        {
            reports.Add(report);
        }
        public void RemoveReport(Guid userId)
        {
            reports.RemoveAll(userOnTrial => userOnTrial.UserId == userId);
        }

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

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            comments.Remove(comment);
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
