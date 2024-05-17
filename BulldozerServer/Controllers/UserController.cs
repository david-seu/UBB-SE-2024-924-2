using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Services;
using Microsoft.EntityFrameworkCore;
using BulldozerServer.Payload.DTO;
using BulldozerServer.Payloads.DTO;

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
           // Guid ownerId = Guid.Parse(Request.Query["id"]);
           userService.RemoveUser(userId);
           return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            await userService.UpdateUser(userDto);
            return NoContent();
        }

        [HttpGet("{userId}/favoritePosts")]
        public async Task<ActionResult<IEnumerable<MarketplacePostDTO>>> GetFavoritePosts(Guid userId)
        {
            try
            {
                List<MarketplacePostDTO> marketplacePosts = await userService.GetFavoritePosts(userId);
                return Ok(marketplacePosts);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet("{userId}/cart")]
        public async Task<ActionResult<IEnumerable<MarketplacePostDTO>>> GetPostsFromCart(Guid userId)
        {
            try
            {
                return await userService.GetPostsFromCart(userId);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost("{userId}/cart/{postId}")]
        public async Task<ActionResult<User>> AddPostToCart(Guid userId, Guid postId)
        {
                userService.AddPostToCart(postId, userId);
                return Ok();
        }

        [HttpPost("{userId}/favoritePosts/{postId}")]
        public async Task<ActionResult<User>> AddPostToFavorites(Guid userId, Guid postId)
        {
            try
            {
                userService.AddPostToFavorites(postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/cart/{postId}")]
        public async Task<ActionResult<User>> RemovePostFromCart(Guid userId, Guid postId)
        {
            try
            {
                userService.RemovePostFromCart(postId, userId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}/favoritePosts/{postId}")]
        public async Task<ActionResult<User>> RemovePostFromFavorites(Guid userId, Guid postId)
        {
            try
            {
                userService.RemovePostFromFavorites(postId, userId);
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

