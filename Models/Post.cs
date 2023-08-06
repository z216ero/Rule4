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
        public virtual List<Tag> Tags { get; set; }
        public string FileId { get; set; }
        public virtual File File { get; set; }
    }
}