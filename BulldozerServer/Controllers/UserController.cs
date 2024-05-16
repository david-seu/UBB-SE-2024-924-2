using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Services;
using Microsoft.EntityFrameworkCore;

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
            return await userService.GetUsers();
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
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var createdUser = await userService.AddUser(user);
            if (UserExists(createdUser.Entity.UserId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(User user)
        {
           userService.RemoveUser(user);
           return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            try
            {
                await userService.UpdateUserUsername(id, user.Username);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

