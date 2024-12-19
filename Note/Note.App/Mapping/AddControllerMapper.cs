using AutoMapper;
using Note.App.Controllers.Add.RequestDto;
using Note.Domain.Model;

namespace Note.App.Mapping;
public class AddControllerMapper : Profile
{
    public AddControllerMapper()
    {
        CreateMap<AddBookDto, BookModel>()
            .ForMember(d => d.BookTitle, opt => opt.MapFrom(s => s.Title));
    }
}
