
using Microsoft.EntityFrameworkCore;
using Note.Data.Database;

namespace Note.Data.Repository;
public class BookRepository : EntityRepository<Book>, IBookRepository
{
    public BookRepository(NoteDbContext context) : base(context)
    {
    }

    public Task<Book?> GetByTitle(string title)
    {
        return _query
            .Where(b => b.Title != null && string.Equals(b.Title.ToLower(), title.ToLower()))
            .FirstOrDefaultAsync();
    }
}
