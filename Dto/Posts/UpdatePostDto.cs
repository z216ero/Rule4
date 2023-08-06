using Rule4.Models;

namespace Rule4.Dto.Posts
{
    public class UpdatePostDto
    {
        public long Id { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
