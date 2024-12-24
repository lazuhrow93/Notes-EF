using Note.Data;
using Note.Data.Repository;
using Note.Domain.Model;

namespace Note.Domain.Services;
public class GetService : IGetService
{
    private readonly IBookRepository _bookRepository;

    public GetService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> GetBook(GetBookModel bookDetails)
        => await _bookRepository.GetByTitle(bookDetails.BookTitle!);
}
