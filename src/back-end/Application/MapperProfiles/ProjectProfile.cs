using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectGetDto>();
        CreateMap<ProjectPostDto, Project>().ReverseMap();
        CreateMap<ProjectPutDto, Project>().ReverseMap();
    }
}