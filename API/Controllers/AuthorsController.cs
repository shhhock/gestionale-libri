using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await unitOfWork.LibraryRepository.GetAllAuthorsAsync();

            if (authors == null || !authors.Any())
            {
                return NotFound("No authors found.");
            }
            var authorDtos = mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await unitOfWork.LibraryRepository.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            var authorDto = mapper.Map<AuthorDto>(author);

            return Ok(authorDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto == null)
            {
                return BadRequest("Author data is null.");
            }

            var createdAuthor = mapper.Map<Author>(authorCreateDto);
            createdAuthor.CreatedDate = DateTime.UtcNow;
            createdAuthor.ModifiedDate = DateTime.UtcNow;

            await unitOfWork.LibraryRepository.AddAuthorAsync(createdAuthor);

            if (await unitOfWork.SaveAsync())
            {
                return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, mapper.Map<AuthorDto>(createdAuthor));
            }

            return StatusCode(500, $"Failed to add author {authorCreateDto.FirstName}.");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto == null)
            {
                return BadRequest("Author data is null.");
            }

            var existingAuthor = await unitOfWork.LibraryRepository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }

            mapper.Map(authorCreateDto, existingAuthor);
            existingAuthor.ModifiedDate = DateTime.UtcNow;
            
            unitOfWork.LibraryRepository.UpdateAuthor(existingAuthor);

            if (await unitOfWork.SaveAsync())
            {
                return NoContent();
            }

            return StatusCode(500, $"Failed to update author with ID {id}.");
        }
    }
}
