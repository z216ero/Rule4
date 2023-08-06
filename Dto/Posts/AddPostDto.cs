using Rule4.Models;

namespace Rule4.Dto.Posts
{
    public class AddPostDto
    {
        public string UserId { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
