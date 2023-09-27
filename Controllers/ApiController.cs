using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCGoogleAuth.Models;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly INewsSevice _newsService;

        public ApiController(INewsSevice newsService)
        {
            _newsService = newsService;
        }

        [Route("api/getnews")]
        [HttpGet]
        public IActionResult GetNews()
        {
            return Ok(_newsService.GetNews());
        }

        [Route("api/getnews/{id}")]
        [HttpGet]
        public IActionResult GetNewsById(int id)
        {
            return Ok(_newsService.GetNewsById(id));
        }

        [Route("api/createnews")]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsDTO newsDto)
        {
            if (newsDto == null)
            {
                return BadRequest("News data is null");
            }

            string? userName = HttpContext.User.Identity.Name;
                        

            return Ok(_newsService.CreateNews(userName, newsDto));
        }

        [Route("api/updatenews/{id}")]
        [HttpPut]
        public IActionResult UpdateNews(int id, [FromBody] NewsDTO newsDto)
        {
            return Ok(_newsService.UpdateNews(id, newsDto));
        }

        [Route("api/deletenews/{id}")]
        [HttpDelete]
        public IActionResult DeleteNews(int id)
        {
            return Ok(_newsService.DeleteNews(id));
        }
    }
}
