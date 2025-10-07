using System;

namespace API.Entities;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Bio { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}
