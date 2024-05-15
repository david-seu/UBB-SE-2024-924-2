using BulldozerServer.Domain;
using BulldozerServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        
    }
}
