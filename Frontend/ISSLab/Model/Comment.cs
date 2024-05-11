﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Model
{
    public class Comment
    {
        private Guid commentId;
        private string content;
        private Guid userId;
        private List<Comment> replies;

        public Comment(Guid userId, string content)
        {
            this.commentId = Guid.NewGuid();
            this.userId = userId;
            this.content = content;
            this.replies = new List<Comment>();
        }

        public Comment()
        {
            this.commentId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.content = Constants.EMPTY_STRING;
            this.replies = new List<Comment>();
        }

        public Comment(Guid commentId, Guid userId, string content, List<Comment> replies)
        {
            this.commentId = commentId;
            this.userId = userId;
            this.content = content;
            this.replies = replies;
        }

        public Guid CommentId { get => commentId; }
        public Guid UserId { get => userId; }
        public string Content { get => content; set => content = value; }
        public List<Comment> Replies { get => replies; }

        public void AddReply(Comment reply)
        {
            replies.Add(reply);
        }
    }
}
