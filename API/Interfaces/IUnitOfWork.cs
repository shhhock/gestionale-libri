using System;

namespace API.Interfaces;

public interface IUnitOfWork
{
    ILibraryRepository LibraryRepository { get; }
    Task<bool> SaveAsync();
    bool HasChanges();
}
