using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface ILibraryRepository
{
    Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
    Task<AuthorDto?> GetAuthorByIdAsync(int id);
    Task AddAuthorAsync(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(Author author);
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<BookDto?> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
}
