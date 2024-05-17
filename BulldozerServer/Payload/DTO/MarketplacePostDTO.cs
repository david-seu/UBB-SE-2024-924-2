using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BulldozerServer.Domain;

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
        private string type;

        public Guid MarketplacePostId { get => marketplacePostId; set => marketplacePostId = value; }
        public Guid? AuthorId { get => authorId; set => authorId = value; }
        public Guid GroupId { get => groupId; set => groupId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string? MediaContent { get => mediaContent; set => mediaContent = value; }
        public string? Location { get => location; set => location = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public bool IsPromoted { get => isPromoted; set => isPromoted = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string Type { get => type; set => type = value; }
    }
}
