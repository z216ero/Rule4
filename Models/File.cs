using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rule4.Models
{
    [Table(name: "Files", Schema = "Data")]
    public class File
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
    }
}