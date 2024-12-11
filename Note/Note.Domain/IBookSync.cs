using Microsoft.EntityFrameworkCore.ChangeTracking;
using Note.Data;
using Note.Domain.Model;

namespace Note.Domain;

public interface IBookSync
{
    Task<EntityEntry<Book>?> Add(BookModel bookModel);
}
