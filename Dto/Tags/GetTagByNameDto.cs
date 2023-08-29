using Rule4.Models;

namespace Rule4.Dto.Tags
{
    public class GetTagByNameDto
    {            
        public string Name { get; set; }
        public string Code { get; set; }
        public int PostCount { get; set; }
        public Models.Type Type { get; set; }
    }
}
