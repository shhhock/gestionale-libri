using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class LibraryRepository(AppDbContext context) : ILibraryRepository
{
    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await context.Authors
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return await context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAuthorAsync(Author author)
    {
        await context.Authors.AddAsync(author);
    }

    public void UpdateAuthor(Author author)
    {
        context.Authors.Update(author);
    }

    public void DeleteAuthor(Author author)
    {
        context.Authors.Remove(author);
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await context.Books
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddBookAsync(Book book)
    {
        await context.Books.AddAsync(book);
    }

    public void UpdateBook(Book book)
    {
        context.Books.Update(book);
    }

    public void DeleteBook(Book book)
    {
        context.Books.Remove(book);
    }
}
