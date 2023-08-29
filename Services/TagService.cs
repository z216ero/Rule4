using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Rule4.Data;
using Rule4.Dto.Tags;
using Rule4.Models;

namespace Rule4.Services
{
    public class TagService : BaseService
    {
        public TagService(IMapper mapper, DataContext dataContext) : base(mapper, dataContext)
        {
        }

        public List<Tag> GetAllTags()
        {
            return _dataContext.Tags.ToList();
        }

        public List<GetTagByNameDto> GetTagsByName(string name)
        {
            var tags = _dataContext.Tags
                .Include(t => t.Posts)
                .Where(t => t.Name.Contains(name))
                .Take(20)
                .OrderByDescending(t => t.Posts.Count);

            return tags.ProjectToType<GetTagByNameDto>().ToList();
        }

        public async Task<bool> SaveTag(Tag tag)
        {
            var existTag = _dataContext.Tags.FirstOrDefault(x => x.Code == tag.Code || x.Name == tag.Name);
            if (existTag == null)
            {
                _dataContext.Tags.Add(tag);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
