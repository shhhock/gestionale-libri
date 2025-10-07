using API.Entities;

namespace API.Interfaces;

public interface ILibraryRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author?> GetAuthorByIdAsync(int id);
    Task AddAuthorAsync(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(Author author);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
}
