namespace BulldozerServer.Payload.DTO
{
        public class MembershipDTO
        {
            private Guid groupId;
            private Guid userId;
            private DateOnly joinDate;
            private bool isBanned;
            private bool isTimedOut;
            private bool isAdmin;
            public Guid GroupId { get => groupId; set => groupId = value; }
            public Guid UserId { get => userId; set => userId = value; }
            public DateOnly JoinDate { get => joinDate; set => joinDate = value; }
            public bool IsBanned { get => isBanned; set => isBanned = value; }
            public bool IsTO { get => isTimedOut; set => isTimedOut = value; }
            public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        }
    }


