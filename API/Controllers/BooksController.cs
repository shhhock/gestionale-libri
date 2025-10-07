using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await unitOfWork.LibraryRepository.GetAllBooksAsync();

            if (books == null || !books.Any())
            {
                return NotFound("No books found.");
            }
            var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await unitOfWork.LibraryRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            var bookDto = mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBook([FromBody] BookCreateDto bookCreateDto)
        {
            if (bookCreateDto == null)
            {
                return BadRequest("Book data is null.");
            }

            var createdBook = mapper.Map<Book>(bookCreateDto);
            createdBook.CreatedDate = DateTime.UtcNow;
            createdBook.ModifiedDate = DateTime.UtcNow;

            await unitOfWork.LibraryRepository.AddBookAsync(createdBook);

            if (await unitOfWork.SaveAsync())
            {
                return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, mapper.Map<BookDto>(createdBook));
            }

            return StatusCode(500, $"Failed to add book {bookCreateDto.Title}.");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookCreateDto bookCreateDto)
        {
            if (bookCreateDto == null)
            {
                return BadRequest("Book data is null.");
            }

            var existingBook = await unitOfWork.LibraryRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            mapper.Map(bookCreateDto, existingBook);
            existingBook.ModifiedDate = DateTime.UtcNow;

            unitOfWork.LibraryRepository.UpdateBook(existingBook);

            if (await unitOfWork.SaveAsync())
            {
                return NoContent();
            }

            return StatusCode(500, $"Failed to update book with ID {id}.");
        }
    }
}
