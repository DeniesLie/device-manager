using Application.Dto;

namespace Application.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectGetDto?> GetProjectByIdAsync(Guid projectId);
    Task<IEnumerable<ProjectGetDto>> GetUserProjectsAsync(string userId);
    Task<IEnumerable<UserDto>> GetUsersInProjectAsync(Guid projectId);
    //Task<IEnumerable<DeviceGetDto>> GetDevicesInProjectAsync(Guid projectId);
    Task<ProjectGetDto> AddProjectAsync(ProjectPostDto projectDto, string projAdminId);
    Task<ProjectGetDto> UpdateProjectAsync(ProjectPutDto projectDto);
    Task<bool> AddContributorToProjectAsync(Guid projectId, string userId);
    Task<bool> KickContributorFromProjectAsync(Guid projectId, string userId);
}