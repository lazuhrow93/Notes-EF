namespace Note.Data.Repository;

public interface IBookRepository : IEntityRepository<Book>
{
    Task<Book?> GetByTitle(string title);
}