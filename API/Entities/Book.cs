using System;

namespace API.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required Author Author { get; set; }
    public DateTime PublishedDate { get; set; }
}
