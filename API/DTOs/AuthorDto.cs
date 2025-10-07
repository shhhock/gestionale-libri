using System;

namespace API.DTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public List<BookDto> Books { get; set; } = [];
}
