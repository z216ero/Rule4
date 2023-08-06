using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Rule4.Dto.Posts;
using Rule4.Models;
using Rule4.Services;

namespace Rule4.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(PostService postService, IWebHostEnvironment webHostEnvironment)
        {
            _postService = postService;
            _webHostEnvironment = webHostEnvironment;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPostDto>))]
        [HttpGet("Get")]
        public IActionResult GetPosts()
        {
            var posts = _postService.GetPosts();
            posts.ForEach(p => p.ImagePath = $"{Request.Scheme}://{Request.Host}/Images/{p.Id}.png");
            return Ok(posts);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPostDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetById")]
        public IActionResult GetById(long postId)
        {
            var existPost = _postService.GetPost(postId);
            if (existPost != null)
            {
                existPost.ImagePath = $"{Request.Scheme}://{Request.Host}/Images/{existPost.Id}.png";
                return Ok(existPost);
            }

            return NotFound(new { error = "Такого поста не существует" });
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] AddPostDto post)
        {
            var addedPost = await _postService.AddPost(post);
            return CreatedAtAction(nameof(GetById), new { id = addedPost.Id }, addedPost);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePost(long postId)
        {
            var isDeleted = await _postService.DeletePost(postId);
            if (isDeleted == true)
                return Ok();

            return NotFound();
        }
    }
}
