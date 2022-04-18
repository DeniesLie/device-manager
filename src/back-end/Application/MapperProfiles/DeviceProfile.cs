using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<DeviceGetDto, Device>();
        CreateMap<DevicePostDto, Device>().ReverseMap();
        CreateMap<DevicePutDto, Device>().ReverseMap();
    }
}