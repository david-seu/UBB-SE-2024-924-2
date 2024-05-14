using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using BulldozerServer.Domain;

namespace BulldozerServer.Controllers
{
    [ApiController] // /api/PostService
    [Route("api/[controller]")]
    public class PostService : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        [HttpGet("GetPosts")]
        public IActionResult GetPosts()
        {
            var allPosts = _postRepository.GetAllPosts();

            if (allPosts == null || allPosts.Count == 0)
            {
                return NotFound("No posts found."); 
            }

            return Ok(allPosts); 
        }
    }

}
