namespace Note.Data.Repository;

public interface IBookRepository
{
    Task<Book?> GetByTitle(string title);
}