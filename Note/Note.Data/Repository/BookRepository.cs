
using Microsoft.EntityFrameworkCore;
using Note.Data.Database;

namespace Note.Data.Repository;
public class BookRepository : IBookRepository
{
    private DbSet<Book> _books;

    public BookRepository(NoteDbContext context)
    {
        _books = context.Books!;    
    }

    public Task<Book?> GetByTitle(string title)
    {
        return _books
            .Where(b => b.Title != null && string.Equals(b.Title.ToLower(), title.ToLower()))
            .FirstOrDefaultAsync();
    }
}
