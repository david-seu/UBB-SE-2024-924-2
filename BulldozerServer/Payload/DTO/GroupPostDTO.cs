﻿using BulldozerServer.Domain;

namespace BulldozerServer.Payload.DTO
{
    public class GroupPostDTO
    {
        private Guid groupPostId;
        private Guid? authorId;
        private Guid groupId;
        private string? mediaContent;
        private DateTime creationDate;
        private string postImage;
        private bool isPinned;
        private bool adminOnly;
        public Guid GroupPostId { get => groupPostId; set => groupPostId = value; }
        public Guid? AuthorId { get => authorId; set => authorId = value; }

        public string PostImage
        {
            get => postImage; set => postImage = value;
        }
        public Guid GroupId { get => groupId; set => groupId = value; }

        public string? PostContent { get => mediaContent; set => mediaContent = value; }

        public DateTime CreationDate { get => creationDate; set => creationDate = value; }

        public bool IsPinned { get => isPinned; set => isPinned = value; }

        public bool AdminOnly { get => adminOnly; set => adminOnly = value; }
    }
}
