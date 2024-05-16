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
        private readonly DatabaseContext databaseContext;
        private PostService postService;

        public PostController(DatabaseContext databaseContext, PostService postService)
        {
            this.databaseContext = databaseContext;
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult AddPost(MarketplacePost post)
        {
            var context = this.postService.AddPost(post);
            if (context == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(context);
            }
        }
    }
}
