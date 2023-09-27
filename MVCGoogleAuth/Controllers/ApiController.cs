﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCGoogleAuth.Models;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth.Controllers
{
    [Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly INewsService _newsService;

        public ApiController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Gets a list of all news items.
        /// </summary>
        /// <returns>
        /// A list of news items.
        /// </returns>
        /// <response code="200">Returns the list of news items.</response>
        [Route("api/getnews")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
            bool isDeleted = _newsService.DeleteNews(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return NotFound("News with the given ID was not found.");
        }
    }
}
