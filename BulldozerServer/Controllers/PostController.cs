using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Mapper;
using BulldozerServer.Payloads.DTO;
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
        public IActionResult AddMarketplacePost(MarketplacePost post)
        {
            try
            {
                MarketplacePostDTO marketplacePostDTO
                var context = this.postService.AddMarketplacePost(post);
                return Ok(context);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult RemoveMarketplacePost(MarketplacePost post)
        {
            try
            {
                var context = this.postService.RemoveMarketplacePost(post);
                return Ok(context);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMarketplacePostById(Guid id)
        {
            try
            {
                var post = this.postService.GetMarketplacePostById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplacePostDTO>>> GetMarketplacePosts()
        {
            return await postService.GetMarketplacePosts();
        }
    }
}
