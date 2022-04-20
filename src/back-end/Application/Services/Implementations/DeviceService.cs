using Application.Dto;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class DeviceService : IDeviceService
{
    private readonly IRepository<Device> _deviceRepo;
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public DeviceService(IRepository<Device> deviceRepo, IProjectService projectService, IMapper mapper)
    {
        _deviceRepo = deviceRepo;
        _projectService = projectService;
        _mapper = mapper;
    }
    
    public async Task<DeviceGetDto> GetDeviceByIdAsync(Guid deviceId)
        => _mapper.Map<DeviceGetDto>(await _deviceRepo.FindByIdAsync(deviceId));

    public async Task<IEnumerable<DeviceGetDto>> GetDevicesInProjectAsync(Guid projectId)
    {
        var project = await _projectService.GetProjectByIdAsync(projectId);
        if (project == null)
            throw new NotFoundException($"Project with id {projectId} does not exists");

        return _mapper.Map<IEnumerable<DeviceGetDto>>
            (await _deviceRepo.FindByCondition(d => d.ProjectId == projectId));
    }

    public async Task<DeviceGetDto> AddDeviceToProjectAsync(DevicePostDto deviceDto)
    {
        if (deviceDto == null)
            throw new NullReferenceException();
        var project = await _projectService.GetProjectByIdAsync(deviceDto.ProjectId);
        if (project == null)
            throw new NotFoundException($"Project with id {deviceDto.ProjectId} does not exists");

        var device = _mapper.Map<Device>(deviceDto);
        _deviceRepo.Add(device);
        await _deviceRepo.SaveChangesAsync();
        return _mapper.Map<DeviceGetDto>(device);
    }

    public async Task<DeviceGetDto> UpdateDeviceAsync(DevicePutDto deviceDto)
    {
        if (deviceDto == null)
            throw new NullReferenceException();
        
        var device = _mapper.Map<Device>(deviceDto);
        _deviceRepo.Update(device);
        await _deviceRepo.SaveChangesAsync();
        return _mapper.Map<DeviceGetDto>(device);
    }

    public async Task<bool> RemoveDeviceAsync(Guid deviceId)
    {
        var device = await _deviceRepo.FindByIdAsync(deviceId);
        if (device == null)
            return false;
        _deviceRepo.Remove(device);
        await _deviceRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveDeviceRangeAsync(IEnumerable<Guid> deviceIds)
    {
        var devicesToDelete = await _deviceRepo.Query().Where(d => deviceIds.Contains(d.Id)).ToListAsync();
        _deviceRepo.RemoveRange(devicesToDelete);
        await _deviceRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeviceExistsAsync(Guid deviceId)
        => await _deviceRepo.Exists(deviceId);
}