using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Genre
{
    public int Id { get; set; }

    [StringLength(50)]
    public required string Name { get; set; }
    
    public ICollection<BookGenre>? BookGenres { get; set; }
}