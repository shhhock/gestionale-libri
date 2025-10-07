using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await unitOfWork.LibraryRepository.GetAllAuthorsAsync();

            if (authors == null || !authors.Any())
            {
                return NotFound("No authors found.");
            }

            return Ok(authors);
        }
    }
}
