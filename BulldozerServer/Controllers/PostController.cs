﻿using BulldozerServer.Domain;
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