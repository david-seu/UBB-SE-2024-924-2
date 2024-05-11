﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model;

namespace ISSLab.Services
{
    public class FakeUserService : IUserService
    {
        public bool AddItemToFavoritesCalled { get; set; }
        public Guid GroupId { get; set; }
        public Guid PostId { get; set; }
        public Guid AccountId { get; set; }
        public bool GetFavoritePostsCalled;
        public bool GetItemsFromCartCalled;

        public bool AddItemToCartCalled { get; set; }

        public void AddPostToFavorites(Guid groupId, Guid postId, Guid accountId)
        {
            AddItemToFavoritesCalled = true;
            GroupId = groupId;
            PostId = postId;
            AccountId = accountId;
        }
        public void AddPostToCart(Guid groupId, Guid postId, Guid accountId)
        {
            AddItemToCartCalled = true;
            GroupId = groupId;
            PostId = postId;
            AccountId = accountId;
        }
        public void AcceptAccessToSell(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public void AddReview(Guid reviewerId, Guid sellerId, Guid groupId, string content, DateTime date, int rating)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void AddUserToGroup(User user, Group group)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string username, string realName, DateOnly dateOfBirth, string profilePicture, string password)
        {
            throw new NotImplementedException();
        }

        public void DenyAccessToSell(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetFavoritePosts(Guid groupId, Guid userId)
        {
            GetFavoritePostsCalled = true;
            return new List<Post>();
        }

        public List<Post> GetPostsFromCart(Guid userId, Guid groupId)
        {
            GetItemsFromCartCalled = true;
            return new List<Post>();
        }

        public User GetUserById(Guid id)
        {
            string expectedUsername = "expected Username";
            User dummyUser = new User(expectedUsername, string.Empty, DateOnly.MaxValue, string.Empty, string.Empty);
            return dummyUser;
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public double GetUserScore(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInGroup(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInGroup(User user, Group group)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccessToSell(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public void RemovePostFromCart(Guid groupId, Guid postId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public void RequestAccessToSell(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserDateOfBirth(Guid user, DateOnly dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(Guid user, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserProfilePicture(Guid user, string profilePicture)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserRealName(Guid user, string realName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserUsername(Guid user, string username)
        {
            throw new NotImplementedException();
        }

        public bool UserIsAdminInGroup(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public bool UserIsMemberInGroup(User userId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public bool UserIsSellerInGroup(Guid userId, Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}
