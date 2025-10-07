using System;
using API.Entities;

namespace API.Data;

public class Seed
{
    public static async Task SeedGenresAsync(AppDbContext context)
    {
        if (!context.Authors.Any())
        {
            context.Authors.Add(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling", BirthDate = new DateTime(1965, 7, 31), CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow }
            );
        }

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book { Title = "Harry Potter and the Philosopher's Stone", AuthorId = 1, PublishedDate = new DateTime(1997, 6, 26), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Chamber of Secrets", AuthorId = 1, PublishedDate = new DateTime(1998, 7, 2), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Prisoner of Azkaban", AuthorId = 1, PublishedDate = new DateTime(1999, 7, 8), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Goblet of Fire", AuthorId = 1, PublishedDate = new DateTime(2000, 7, 8), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Order of the Phoenix", AuthorId = 1, PublishedDate = new DateTime(2003, 6, 21), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Half-Blood Prince", AuthorId = 1, PublishedDate = new DateTime(2005, 7, 16), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow },
                new Book { Title = "Harry Potter and the Deathly Hallows", AuthorId = 1, PublishedDate = new DateTime(2007, 7, 21), CreatedDate = DateTime.UtcNow , ModifiedDate = DateTime.UtcNow }
            );
        }

        if (!context.Genres.Any())
        {
            context.Genres.AddRange(
             new Genre { Id = 1, Name = "Fiction" },
             new Genre { Id = 2, Name = "Fantasy" },
             new Genre { Id = 3, Name = "Science Fiction" },
             new Genre { Id = 4, Name = "Detective" },
             new Genre { Id = 5, Name = "Thriller" },
             new Genre { Id = 6, Name = "Horror" },
             new Genre { Id = 7, Name = "Romance" },
             new Genre { Id = 8, Name = "Historical" },
             new Genre { Id = 9, Name = "Biography" },
             new Genre { Id = 10, Name = "Non-Fiction" },
             new Genre { Id = 11, Name = "Philosophy" },
             new Genre { Id = 12, Name = "Poetry" },
             new Genre { Id = 13, Name = "Theatre" },
             new Genre { Id = 14, Name = "Adventure" },
             new Genre { Id = 15, Name = "Dystopia" },
             new Genre { Id = 16, Name = "Mystery" },
             new Genre { Id = 17, Name = "Humor" },
             new Genre { Id = 18, Name = "Young Adult" },
             new Genre { Id = 19, Name = "Children" },
             new Genre { Id = 20, Name = "Comics/Graphic Novel" },
             new Genre { Id = 21, Name = "Manual/Technical" },
             new Genre { Id = 22, Name = "Cooking" },
             new Genre { Id = 23, Name = "Travel" },
             new Genre { Id = 24, Name = "Art" },
             new Genre { Id = 25, Name = "Science" }
            );
        }


        await context.SaveChangesAsync();
    }
}
