using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserService : Controller
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("AddPostToCart")]
        public IActionResult AddPostToCart(Guid groupId, Guid postId, Guid userId)
        {
            userRepository.AddPostToCart(groupId, userId, postId);
            return Ok();
        }
    }
}
