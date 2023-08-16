using Microsoft.AspNetCore.Mvc;
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
    }
}
