using System;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class LibraryRepository(AppDbContext context, IMapper mapper) : ILibraryRepository
{
    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        return await context.Authors
            .Include(a => a.Books)
            .ProjectTo<AuthorDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
    {
        return await context.Authors
            .Include(a => a.Books)
            .ProjectTo<AuthorDto>(mapper.ConfigurationProvider) 
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

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        return await context.Books
            .Include(b => b.Author)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        return await context.Books
            .Include(b => b.Author)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
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
