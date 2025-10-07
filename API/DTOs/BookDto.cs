using System;
using API.Entities;

namespace API.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public BookAuthorDto Author { get; set; } = null!;
    public DateTime PublishedDate { get; set; }
    public List<GenreDto> Genres { get; set; } = [];
}

public class BookAuthorDto
{
    public int Id { get; set; }
    // public string FirstName { get; set; } = string.Empty;
    // public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty; //=> $"{FirstName} {LastName}";
    // public string Biography { get; set; } = string.Empty;
    // public DateTime BirthDate { get; set; }
}

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public DateTime PublishedDate { get; set; }
}