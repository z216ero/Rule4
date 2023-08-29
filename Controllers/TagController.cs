using Microsoft.AspNetCore.Mvc;
using Rule4.Dto.Tags;
using Rule4.Models;
using Rule4.Services;

namespace Rule4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly TagService _tagService;
        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tag>))]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var tags = _tagService.GetAllTags();
            return Ok(tags);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTagByNameDto>))]
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name = "")
        {
            var tags = _tagService.GetTagsByName(name);
            return Ok(tags);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddTag([FromBody] Tag tag)
        {
            var addResult = await _tagService.SaveTag(tag);
            if (addResult)
            {
                return Ok(true);
            }
            return BadRequest();
        }
    }
}
