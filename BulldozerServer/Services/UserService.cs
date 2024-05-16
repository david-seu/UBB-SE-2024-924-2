using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Mapper;
using BulldozerServer.Payload.DTO;
using ISSLab.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext context;

        public UserService(DatabaseContext context)
        {
            this.context = context;
        }

        public async void AddPostToCart(Guid groupId, Guid postId, Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = await context.MarketplacePosts.FindAsync(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.PostsInCart.Add(foundPost);
            context.SaveChangesAsync();
        }

        public async void AddPostToFavorites(Guid groupId, Guid postId, Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = await context.MarketplacePosts.FindAsync(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.FavoritePosts.Add(foundPost);
            context.SaveChangesAsync();
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var addedUser = await context.Users.AddAsync(UserMapper.MapUserDtoToUser(userDto));
            await context.SaveChangesAsync();
            return UserMapper.MapUserToUserDto(addedUser.Entity);
        }

        public async Task<List<MarketplacePost>> GetFavoritePosts(Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser.FavoritePosts.ToList();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var foundUser = await context.Users.FindAsync(id);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser;
        }

        public Task<List<User>> GetUsers()
        {
            var users = context.Users.ToListAsync();
            // if (users == null)
            // {
            //    throw new Exception("No users found");
            // }
            return users;
        }

        public async Task<bool> IsUserInGroup(Guid userId, Guid groupId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundGroup = await context.Groups.FindAsync(groupId);
            if (foundGroup == null)
            {
                throw new Exception("Group not found");
            }
            return foundUser.Groups.Contains(foundGroup);
        }

        public async void RemovePostFromCart(Guid groupId, Guid postId, Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = await context.MarketplacePosts.FindAsync(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.PostsInCart.Remove(foundPost);
            await context.SaveChangesAsync();
        }

        public async void RemovePostFromFavorites(Guid groupId, Guid postId, Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = await context.MarketplacePosts.FindAsync(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            foundUser.FavoritePosts.Remove(foundPost);
            await context.SaveChangesAsync();
        }

        public void RemoveUser(Guid userId)
        {
            Console.WriteLine("Removing user");
            var userToRemove = context.Users.Find(userId);
            if (userToRemove == null)
            {
                throw new Exception("User not found");
            }
            Console.WriteLine("Removing user 2");
            context.Users.Remove(userToRemove);
            Console.WriteLine("Removing user 3");
            context.SaveChanges();
            Console.WriteLine("Removing user 4");
        }

        public async Task<User> UpdateUserUsername(Guid userId, string username)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            foundUser.Username = username;
            context.Users.Update(foundUser);
            context.SaveChangesAsync();
            return foundUser;
        }

        public async Task<List<MarketplacePost>> GetPostsFromCart(Guid userId, Guid groupId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return foundUser.PostsInCart.ToList();
        }
    }
}
