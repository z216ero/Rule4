using Rule4.Models;

namespace Rule4.Dto.Posts
{
    public class GetPostDto
    {
        public long Id { get; set; }
        public string ImagePath { get; set; }
        public long LikeCount { get; set; }
        public long ViewCount { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
