using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostService : Controller
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            if (post == null)
            {
                return BadRequest("Post is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            postRepository.AddPost(post);

            //return CreatedAtAction(nameof(AddPost), new { id = post.Id }, post);  Location header that contains the URI of the newly created post
            return Ok();
        }

        [HttpGet("{userId}/cart")]
        public IActionResult GetPostsFromCart(Guid userId)
        {
            var postsInCart = userRepository.GetPostsFromCart(userId);
            if (postsInCart == null || postsInCart.Count == 0)
            {
                return NotFound("No posts found in the cart.");
            }

            return Ok(postsInCart);
        }


    }
}