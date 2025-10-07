using System;

namespace API.Entities;

public class Author
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string Biography { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }

    public ICollection<Book> Books { get; set; } = [];

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
