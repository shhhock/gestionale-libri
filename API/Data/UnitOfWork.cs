using System;
using API.Interfaces;

namespace API.Data;

public class UnitOfWork(AppDbContext context, ILibraryRepository libraryRepository) : IUnitOfWork
{
    public ILibraryRepository LibraryRepository => libraryRepository;
    
    public bool HasChanges()
    {
        return context.ChangeTracker.HasChanges();
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}