using Microsoft.AspNetCore.Mvc;
using Note.App.Controllers.Get.RequestDto;
using Note.Data;
using Note.Data.Repository;

namespace Note.App.Controllers.Get;

public class GetController : NoteController
{
    private IBookRepository _bookRepository;
    private ILogger<GetController> _logger;

    public GetController(IBookRepository bookRepository,
        ILogger<GetController> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<Book?> GetBook(GetBookRequestDto requestDto)
    {
        if(requestDto.BookTitle == null)
        {
            throw new Exception($"request needs a book title");
        }

        return await _bookRepository.GetByTitle(requestDto.BookTitle);
    }
}
