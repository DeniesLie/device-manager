using Application.Dto;
using Domain.Entities;
using Domain;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly IRepository<Project> _projectRepo;
    private readonly IRepository<ProjectMembership> _membersRepo;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(IRepository<Project> projectRepo, IRepository<ProjectMembership> membersRepo, IUserService userService,IMapper mapper, ILogger<ProjectService> logger)
    {
        _projectRepo = projectRepo;
        _membersRepo = membersRepo;
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<ProjectGetDto?> GetProjectByIdAsync(Guid projectId)
        => _mapper.Map<ProjectGetDto>(await _projectRepo.FindByIdAsync(projectId));

    public async Task<IEnumerable<ProjectGetDto>> GetUserProjectsAsync(string userId)
    {
        return _mapper.Map<IEnumerable<ProjectGetDto>>(
            await _membersRepo.Query(m => m.Project)
                .Where(m => m.UserId == userId)
                .Select(m => m.Project)
                .ToListAsync());
    }

    public async Task<IEnumerable<UserDto>> GetUsersInProjectAsync(Guid projectId)
    {
        return _mapper.Map<IEnumerable<UserDto>>(
            await _membersRepo.Query(m => m.User)
                .Where(m => m.ProjectId == projectId)
                .Select(m => m.User)
                .ToListAsync());
    }

    // public async Task<IEnumerable<DeviceGetDto>> GetDevicesInProjectAsync(Guid projectId)
    // {
    //     return _mapper.Map<IEnumerable<DeviceGetDto>>(
    //         await _deviceRepo.Query()
    //             .Where(d => d.ProjectId == projectId)
    //             .ToListAsync());
    // }

    public async Task<ProjectGetDto> AddProjectAsync(ProjectPostDto projectPostDto, string projAdminId)
    {
        var projAdmin = _userService.GetUserById(projAdminId);
        var project = _mapper.Map<Project>(projectPostDto);
        project.Id = new Guid();
        project.Memberships.Add(
            new ProjectMembership() {
                ProjectId = project.Id, 
                UserId = projAdminId, 
                ProjectRole = ProjectRole.Admin
            });
        _projectRepo.Add(project);
        await _projectRepo.SaveChangesAsync();
        return _mapper.Map<ProjectGetDto>(project);
    }

    public async Task<ProjectGetDto> UpdateProjectAsync(ProjectPutDto projectDto)
    {
        var updateProj = _mapper.Map<Project>(projectDto);
        _projectRepo.Update(updateProj);
        await _projectRepo.SaveChangesAsync();
        return _mapper.Map<ProjectGetDto>(updateProj);
    }

    public async Task<bool> AddContributorToProjectAsync(Guid projectId, string userId)
    {
        var project = await _projectRepo.FindByIdAsync(projectId);
        var user = await _userService.GetUserById(userId);
        if (project == null || user == null)
            return false;

        var newMembership = new ProjectMembership()
        {
            ProjectId = projectId,
            UserId = userId,
            ProjectRole = ProjectRole.Contributor
        };
        _membersRepo.Add(newMembership);
        await _membersRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> KickContributorFromProjectAsync(Guid projectId, string userId)
    {
        var project = await _projectRepo.FindByIdAsync(projectId);
        var user = await _userService.GetUserById(userId);
        if (project == null || user == null)
            return false;

        var membership = await _membersRepo.FindByIdAsync(projectId, userId);
        if (membership == null)
            return false;
        
        _membersRepo.Remove(membership);
        await _membersRepo.SaveChangesAsync();
        return true;
    }
}