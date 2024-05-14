using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet("GetCartPosts")]
        public IActionResult GetCartPosts(Guid userId)
        {
            var cartPosts = userRepository.GetCartPosts(userId);

            if (cartPosts == null || !cartPosts.Any())
            {
                return NotFound("Cart is empty");
            }

            return Ok(cartPosts);
        }
    }
}