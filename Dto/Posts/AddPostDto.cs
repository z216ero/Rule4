using Rule4.Dto.Tags;

namespace Rule4.Dto.Posts
{
    public class AddPostDto
    {
        public string Tags { get; set; }
        public IFormFile File { get; set; }
    }
}
