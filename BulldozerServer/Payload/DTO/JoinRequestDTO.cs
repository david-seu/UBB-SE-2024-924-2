namespace BulldozerServer.Payload.DTO
{
    public class JoinRequestDTO
    {
        private Guid joinRequestId;
        private Guid userId;
        private Guid groupId;

        public Guid JoinRequestId { get => joinRequestId; set => joinRequestId = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public Guid GroupId { get => groupId; set => groupId = value; }
    }
}
