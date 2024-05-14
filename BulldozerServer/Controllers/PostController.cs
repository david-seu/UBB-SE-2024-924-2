using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using BulldozerServer.Domain;

namespace BulldozerServer.Controllers
{
    [ApiController] // /api/PostService
    [Route("api/[controller]")]
    public class PostService : Controller
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet("GetPosts")]
        public IEnumerable<MarketplacePost> GetPosts()
        {
            return postRepository.GetAllPosts();
        }
    }

}
