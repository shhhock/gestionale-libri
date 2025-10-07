using System;

namespace API.DTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Biography { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public List<AuthorBookDto> Books { get; set; } = [];
}

public class AuthorBookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public List<GenreDto> Genres { get; set; } = [];
}

public class AuthorCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}