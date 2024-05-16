﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSLab.Domain
{
    public class Request
    {
        private Guid joinRequestId;
        private Guid userId;
        private Guid groupId;

        public Request(Guid userId, Guid groupId)
        {
            this.joinRequestId = Guid.NewGuid();
            this.userId = userId;
            this.groupId = groupId;
        }

        public Request()
        {
            this.userId = Guid.NewGuid();
            this.groupId = Guid.NewGuid();
        }

        public Request(Guid joinRequestId, Guid userId, Guid groupId)
        {
            this.joinRequestId = joinRequestId;
            this.userId = userId;
            this.groupId = groupId;
        }

        [Key]
        public Guid JoinRequestId { get => joinRequestId; }
        public Guid UserId { get => userId; }
        public Guid GroupId { get => groupId; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
