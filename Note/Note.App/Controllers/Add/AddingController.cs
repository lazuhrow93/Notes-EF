using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Note.App.Controllers.Add.RequestDto;
using Note.Domain;
using Note.Domain.Model.Entity;

namespace Note.App.Controllers;

[ApiController]
[Route("[controller]")]
public partial class AddingController : NoteController
{
    private readonly IMapper _mapper;

    private readonly IBookSync _bookSync;
    private readonly ILogger<AddingController> _logger;

    public AddingController(IBookSync bookSync,
        IMapper mapper,
        ILogger<AddingController> logger)
    {
        _bookSync = bookSync;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet(Name = "Book")]
    public async Task AddBook(AddBookDto addBookRequest)
    {
        //TODO: Add validator to check if the book has all properties .

        var mappedValue = _mapper.Map<BookModel>(addBookRequest);
        var result = await _bookSync.Add(mappedValue);

        if (result?.State != Microsoft.EntityFrameworkCore.EntityState.Added)
        {
            LogBookNotAdded(mappedValue.BookTitle!);
            throw new Exception($"Did not add the book");
        }
    }
}

public partial class AddingController
{
    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Unable to add book | Book Title => {bookTitle}")]
    public partial void LogBookNotAdded(string bookTitle);
}
