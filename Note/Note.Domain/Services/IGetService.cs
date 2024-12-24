using Note.Data;
using Note.Domain.Model;

namespace Note.Domain.Services;
public interface IGetService
{
    Task<Book?> GetBook(GetBookModel bookDetails);
}