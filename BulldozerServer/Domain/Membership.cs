using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulldozerServer.Domain
{
    public class Membership
    {
        private Guid groupId;
        private Guid userId;
        private DateOnly joinDate;
        private bool isBanned;
        private bool isTimedOut;
        private bool isAdmin;

        public Membership(Guid groupId, Guid userId, DateOnly joinDate, bool isBanned, bool isTimedOut, bool isAdmin)
        {
            this.groupId = groupId;
            this.userId = userId;
            this.joinDate = joinDate;
            this.isBanned = isBanned;
            this.isTimedOut = isTimedOut;
            this.isAdmin = isAdmin;
        }

        public Membership()
        {
            this.groupId = Guid.NewGuid();
            this.userId = Guid.NewGuid();
            this.joinDate = DateOnly.FromDateTime(DateTime.Now);
            this.isBanned = false;
            this.isTimedOut = false;
            this.isAdmin = false;
        }

        public Membership(Guid groupId, Guid userId)
        {
            this.groupId = groupId;
            this.userId = userId;
            this.joinDate = DateOnly.FromDateTime(DateTime.Now);
            this.isBanned = false;
            this.isTimedOut = false;
            this.isAdmin = false;
        }

        [Key]
        public Guid GroupId { get => groupId; }
        public Guid UserId { get => userId; }
        public DateOnly JoinDate { get => joinDate; }
        public bool IsBanned { get => isBanned; set => isBanned = value; }
        public bool IsTO { get => isTimedOut; set => isTimedOut = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
