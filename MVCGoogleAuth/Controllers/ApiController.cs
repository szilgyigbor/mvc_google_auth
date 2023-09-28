using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCGoogleAuth.Models;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth.Controllers
{
    /// <summary>
    /// API controller for managing news items. Provides CRUD operations.
    /// </summary>
    [Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly INewsService _newsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController"/> class.
        /// </summary>
        /// <param name="newsService">The news service to be used for CRUD operations.</param>
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

        /// <summary>
        /// Gets a news item selected by id.
        /// </summary>
        /// <param name="id">The id of the news item.</param>
        /// <returns>
        /// A news item.
        /// </returns>
        /// <response code="200">Returns the news item.</response>
        [Route("api/getnews/{id}")]
        [HttpGet]
        public IActionResult GetNewsById(int id)
        {
            return Ok(_newsService.GetNewsById(id));
        }

        /// <summary>
        /// Create a news item with the required contents.
        /// </summary>
        /// <param name="newsDto">The model of the news data transfer object.</param>
        /// <returns>
        /// The created news item.
        /// </returns>
        /// <response code="200">Returns the news item.</response>
        /// <response code="400">Returns an error if the news data is null.</response>
        /// <remarks>
        /// This method also attempts to obtain the username from the HttpContext. 
        /// If the username is not found (e.g., authorization is disabled), 
        /// it defaults to "unidentified user".
        /// </remarks>
        [Route("api/createnews")]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsDTO newsDto)
        {
            if (newsDto == null)
            {
                return BadRequest("News data is null");
            }

            string? userName = HttpContext.User.Identity.Name;

            if (userName == null)
            {
                userName = "unidentified user";
            }

            return Ok(_newsService.CreateNews(userName, newsDto));
        }

        /// <summary>
        /// Update a selected news item with the modified contents.
        /// </summary>
        /// <param name="id">The id of the selected news item.</param>
        /// <param name="newsDto">The model of the news data transfer object.</param>
        /// <returns>
        /// The updated news item.
        /// </returns>
        /// <response code="200">Returns the news item.</response>
        [Route("api/updatenews/{id}")]
        [HttpPut]
        public IActionResult UpdateNews(int id, [FromBody] NewsDTO newsDto)
        {
            return Ok(_newsService.UpdateNews(id, newsDto));
        }

        /// <summary>
        /// Delete a selected news item.
        /// </summary>
        /// <param name="id">The id of the selected news item.</param>
        /// <returns>
        /// A boolean value indicating whether the deletion was successful or not.
        /// </returns>
        /// <response code="200">Returns true if the news item was successfully deleted.</response>
        /// <response code="404">Returns a message if the news with the given ID was not found.</response>
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
