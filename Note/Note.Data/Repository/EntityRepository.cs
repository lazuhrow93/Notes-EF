using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Note.Data.Database;

namespace Note.Data.Repository;

public class EntityRepository<T> : IEntityRepository<T>
    where T : Entity
{
    private readonly NoteDbContext _context;
    protected DbSet<T> _query => _context.Set<T>();

    public EntityRepository(NoteDbContext context)
    {
        _context = context;
    }

    public EntityEntry<T> Add(T entity)
    {
        return _query.Add(entity);
    }

    public void Save()
        => _context.SaveChanges();
}
