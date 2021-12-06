using LeftTuesday.Models;
using LeftTuesday.Repository;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("Content")]
    public class ContentController : BaseController
    {
        //TODO DI
        private ContentService _contentService;
        public ContentController(ContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("all")]
        public IActionResult GetAllContents()
        {
            return ReturnValueOrError(_contentService.GetContents());
        }

        [HttpGet("get")]
        public IActionResult GetContent([FromQuery] int contentId)
        {
            return ReturnValueOrError(_contentService.GetContent(contentId));
        }

        [HttpPost("create")]
        public IActionResult CreateContent([FromBody] Content content)
        {
            return ReturnValueOrError(_contentService.CreateContent(content));
        }

        [HttpPut("update")]
        public IActionResult UpdateContent([FromBody] Content content)
        {
            return ReturnValueOrError(_contentService.UpdateContent(content));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteContent([FromQuery] int contentId)
        {
            return ReturnValueOrError(_contentService.DeleteContent(contentId));
        }
    }
}
