﻿using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payload.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public interface IUserService
    {
        void AddPostToCart(Guid groupId, Guid postId, Guid userId);
        void AddPostToFavorites(Guid groupId, Guid postId, Guid userId);
        Task<UserDto> AddUser(UserDto userDto);
        Task<List<MarketplacePost>> GetFavoritePosts(Guid userId);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetUsers();
        Task<bool> IsUserInGroup(Guid userId, Guid groupId);
        void RemovePostFromCart(Guid groupId, Guid postId, Guid userId);
        void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId);
        void RemoveUser(Guid userId);
        Task<User> UpdateUserUsername(UserDto userDto);
        Task<List<MarketplacePost>> GetPostsFromCart(Guid userId, Guid groupId);
    }
}