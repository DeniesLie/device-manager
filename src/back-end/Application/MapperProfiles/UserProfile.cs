using Domain.Entities;
using Application.Dto;
using AutoMapper;

namespace Application.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}