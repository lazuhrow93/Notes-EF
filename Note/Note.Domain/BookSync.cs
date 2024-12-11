using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Note.Data;
using Note.Data.Database;
using Note.Data.Repository;
using Note.Domain.Model;

namespace Note.Domain;

public class BookSync : IBookSync
{
    private readonly NoteDbContext _context;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookSync(NoteDbContext noteDbContext,
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _context = noteDbContext;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<EntityEntry<Book>?> Add(BookModel bookModel)
    {
        if (bookModel.BookTitle == null)
            return null;

        var result = await _bookRepository.GetByTitle(bookModel.BookTitle);
        if (result != null)
            return null;

        var newEntity = _mapper.Map<Book>(bookModel);

        var addResult = _bookRepository.Add(newEntity);
        _bookRepository.Save();

        return addResult;
    }
}
