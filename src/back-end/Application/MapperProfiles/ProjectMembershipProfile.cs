using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles;

public class ProjectMembershipProfile : Profile
{
    public ProjectMembershipProfile()
    {
        CreateMap<ProjectMembership, ProjectMembershipDto>().ReverseMap();
    }
}