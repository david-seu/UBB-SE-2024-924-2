using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult AddPost(MarketplacePost post)
        {
            try
            {
                var context = this.postService.AddPost(post);
                return Ok(context);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult RemovePost(MarketplacePost post)
        {
            try
            {
                var context = this.postService.RemovePost(post);
                return Ok(context);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var post = this.postService.GetPostById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{}")]
        public async Task<ActionResult<IEnumerable<MarketplacePost>>> GetPosts()
        {
            return await postService.GetPosts();
        }
    }
}
