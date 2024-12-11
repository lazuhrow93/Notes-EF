using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Note.Data.Repository;

public interface IEntityRepository<T>
    where T : Entity
{
    EntityEntry<T> Add(T entity);
    void Save();

}
