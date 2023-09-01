using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rule4.Models
{
    [Table(name: "Tags", Schema = "Data")]
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public List<Post> Posts { get; set; }
        public TagType Type { get; set; }
    }

    public enum TagType
    {
        Copyright,
        General,
        Artist,
        Character
    }
}
