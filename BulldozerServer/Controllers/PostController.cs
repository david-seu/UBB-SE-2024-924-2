using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BulldozerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostService : Controller
    {
        // private readonly IPostRepository postRepository;

        // public PostService(IPostRepository postRepository)
        // {
        //    this.postRepository = postRepository;
        // }

        // [HttpDelete("{id}")]
        // public IActionResult RemovePost(Post post)
        // {
        //    postRepository.RemovePost(post.Id);
        //    return Ok();
        // }
    }
}
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


    }
}
