using System;

namespace API.Entities;

public class Book
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; } = [];
    
    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
