using Microsoft.AspNetCore.Mvc;
using Rule4.Dto.Posts;
using Rule4.Models;
using Rule4.Services;

namespace Rule4.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            posts.ForEach(p => p.ImagePath = $"{Request.Scheme}://{Request.Host}/Images/{p.Id}{p.FileExtension}");
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
                existPost.ImagePath = $"{Request.Scheme}://{Request.Host}/Images/{existPost.Id}{existPost.FileExtension}";
                return Ok(existPost);
            }

            return NotFound(new { error = "Такого поста не существует" });
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddPost([FromForm] AddPostDto post)
        {
            var addedPost = await _postService.AddPost(post);
            SaveNewFile(post.File, addedPost.Id);

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

        private void SaveNewFile(IFormFile file, long postId)
        {
            if (file != null && file.Length > 0)
            {
                // Определите путь для сохранения файла в папку wwwroot
                var webRootPath = _webHostEnvironment.WebRootPath;
                var extension = Path.GetExtension(file.FileName);
                var fullFileName = $"{postId}{extension}";
                var filePath = Path.Combine(webRootPath, "Images", fullFileName);

                // Создайте директорию, если она не существует
                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Сохраните файл
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
        }
    }
}
