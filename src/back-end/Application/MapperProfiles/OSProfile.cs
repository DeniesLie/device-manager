using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles;

public class OSProfile : Profile
{
    public OSProfile()
    {
        CreateMap<OS, OSDto>().ReverseMap();
    }
}