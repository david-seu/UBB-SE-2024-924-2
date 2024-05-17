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
using BulldozerServer.Payloads.DTO;
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

        public void AddPostToCart(Guid postId, Guid userId)
        {
            var foundUser = context.Users.Find(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = context.MarketplacePosts.Find(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            Cart cart = new Cart { UserId = userId, MarketplacePostId = postId };
            context.Cart.Add(cart);
            context.SaveChanges();
        }

        public void AddPostToFavorites(Guid postId, Guid userId)
        {
            var foundUser = context.Users.Find(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var foundPost = context.MarketplacePosts.Find(postId);
            if (foundPost == null)
            {
                throw new Exception("Post not found");
            }
            UsersFavoritePosts usersFavoritePosts = new UsersFavoritePosts { UserId = userId, MarketplacePostId = postId };
            var result = context.UsersFavoritePosts.Add(usersFavoritePosts);
            context.SaveChanges();
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            // comments
            var addedUser = await context.Users.AddAsync(UserMapper.MapUserDtoToUser(userDto));
            await context.SaveChangesAsync();
            return UserMapper.MapUserToUserDto(addedUser.Entity);
        }

        public async Task<List<MarketplacePostDTO>> GetFavoritePosts(Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            var favoritePosts = context.MarketplacePosts.Where(post => post.AuthorId == userId).ToList();
            return favoritePosts.Select(post => MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post)).ToList();
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
            return foundUser.GroupsPartOf.Contains(foundGroup);
        }

        public async void RemovePostFromCart(Guid postId, Guid userId)
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

        public async void RemovePostFromFavorites(Guid postId, Guid userId)
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
            var userToRemove = context.Users.Find(userId);
            if (userToRemove == null)
            {
                throw new Exception("User not found");
            }
            context.Users.Remove(userToRemove);
            context.SaveChanges();
        }

        public async Task<User> UpdateUser(UserDto userDto)
        {
            var foundUser = await context.Users.FindAsync(userDto.UserId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            foundUser.Username = userDto.Username;
            foundUser.FullName = userDto.FullName;
            foundUser.Email = userDto.Email;
            foundUser.PhoneNumber = userDto.PhoneNumber;
            foundUser.Password = userDto.Password;
            foundUser.BirthDay = userDto.BirthDay;
            context.Users.Update(foundUser);
            context.SaveChanges();
            return foundUser;
        }

        public async Task<List<MarketplacePostDTO>> GetPostsFromCart(Guid userId)
        {
            var foundUser = await context.Users.FindAsync(userId);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            List<Guid> postIds = context.Cart.Where(cart => cart.UserId == userId).Select(cart => cart.MarketplacePostId).ToList();
            List<MarketplacePostDTO> posts = new List<MarketplacePostDTO>();
            foreach (Guid id in postIds)
            {
                var post = await context.MarketplacePosts.FindAsync(id);
                if (post != null)
                {
                    posts.Add(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(post));
                }
            }
            return posts;
        }
    }
}
