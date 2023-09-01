using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rule4.Models
{
    [Table("Post", Schema = "Data")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public long LikeCount { get; set; }
        public long ViewCount { get; set; }
        public List<Tag> Tags { get; set; }
        public string Source { get; set; }
        public string FileExtension { get; set; }
        public DateTime? Added { get; set; }
    }
}