using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ISSLab.Services;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("AddPostToCart")]
        public IActionResult AddPostToCart(Guid groupId, Guid postId, Guid userId)
        {
            userService.AddPostToCart(groupId, postId, userId);
            return Ok();
        }

        [HttpPost("AddPostToFavorite")]
        public IActionResult AddPostToFavorite(Guid groupId, Guid postId, Guid userId)
        {
            userService.AddPostToFavorites(groupId, postId, userId);
            return Ok();
        }
    }
}
