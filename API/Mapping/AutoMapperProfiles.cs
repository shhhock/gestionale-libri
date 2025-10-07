using System;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, BookAuthorDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        CreateMap<AuthorCreateDto, Author>();

        CreateMap<Book, BookDto>();
        CreateMap<Book, AuthorBookDto>();
        CreateMap<BookCreateDto, Book>();

        CreateMap<Genre, GenreDto>();

        CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
        CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
        CreateMap<DateTime?, DateTime?>().ConvertUsing(d => d.HasValue
            ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
    }
}
