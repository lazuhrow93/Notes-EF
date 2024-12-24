using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Note.App.Controllers.Get.RequestDto;
using Note.Domain.Model;
using Note.Domain.Model.Entity;

namespace Note.App.Controllers.Get.Mapping;

public class GetControllerMapper : Profile
{
    public GetControllerMapper()
    {
        CreateMap<GetBookRequestDto, GetBookModel>()
            .ForMember(d => d.BookTitle, opt => opt.MapFrom(s => s.BookTitle));
    }
}
