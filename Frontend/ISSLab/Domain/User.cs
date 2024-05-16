﻿using System.ComponentModel.DataAnnotations;
using ISSLab.Domain.MarketplacePosts;

namespace ISSLab.Domain
{
    public class User
    {
        private Guid userId;
        private string username;
        private string fullName;
        private string password;
        private string email;
        private string phoneNumber;
        private DateOnly birthDay;
        private DateTime createdDate;

        public Guid UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateOnly BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ICollection<MarketplacePost> PostsInCart { get; set; }

        public ICollection<MarketplacePost> FavoritePosts { get; set; }
        public ICollection<Group> Groups { get; }

        public ICollection<MarketplacePost> MarketplacePosts { get; } = new List<MarketplacePost>();
    }
}