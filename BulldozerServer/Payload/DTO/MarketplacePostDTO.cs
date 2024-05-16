namespace BulldozerServer.Payloads.DTO
{
    public class MarketplacePostDTO
    {
        private Guid marketplacePostId;
        private Guid? authorId;
        private Guid groupId;
        private string title;
        private string description;
        private string? mediaContent;
        private string? location;
        private DateTime creationDate;
        private DateTime? endDate;
        private bool isPromoted;
        private bool isActive;


    }
}
