﻿using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Services;
using Microsoft.EntityFrameworkCore;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await userService.GetUsers());
            // try
            // {
            // }
            // catch (Exception e)
            // {
            //    return NotFound(e);
            // }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            try
            {
                var user = await userService.GetUserById(id);
                return user;
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserDto userDto)
        {
            var createdUser = await userService.AddUser(userDto);
            return Ok(createdUser);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(Guid userId)
        {
           // Guid userId = Guid.Parse(Request.Query["id"]);
           userService.RemoveUser(userId);
           return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            await userService.UpdateUserUsername(userDto);
            return NoContent();
        }

        [HttpGet("{userId}/favoritePosts")]
        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetFavoritePosts(Guid userId)
        {
            try
            {
                return await userService.GetFavoritePosts(userId);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet("{userId}/cart")]
        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetPostsFromCart(Guid userId, Guid groupId)
        {
            try
            {
                return await userService.GetPostsFromCart(userId, groupId);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost("{userId}/cart/{postId}")]
        public async Task<ActionResult<User>> AddPostToCart(Guid userId, Guid postId, Guid groupId)
        {
            try
            {
                userService.AddPostToCart(groupId, postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost("{userId}/favoritePosts/{postId}")]
        public async Task<ActionResult<User>> AddPostToFavorites(Guid userId, Guid postId, Guid groupId)
        {
            try
            {
                userService.AddPostToFavorites(groupId, postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/cart/{postId}")]
        public async Task<ActionResult<User>> RemovePostFromCart(Guid userId, Guid postId, Guid groupId)
        {
            try
            {
                userService.RemovePostFromCart(groupId, postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/favoritePosts/{postId}")]
        public async Task<ActionResult<User>> RemovePostFromFavorites(Guid userId, Guid postId, Guid groupId)
        {
            try
            {
                userService.RemovePostFromFavorites(groupId, postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        private bool UserExists(Guid id)
        {
            return userService.GetUsers().Result.Any(e => e.UserId == id);
        }
    }
}

