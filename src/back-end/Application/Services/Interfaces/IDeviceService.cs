using Application.Dto;

namespace Application.Services.Interfaces;

public interface IDeviceService
{
    Task<DeviceGetDto> GetDeviceById(Guid deviceId);
    Task<IEnumerable<DeviceGetDto>> GetDevicesInProjectAsync(Guid projectId);
    Task<DeviceGetDto> AddDeviceToProjectAsync(DevicePostDto deviceDto);
    Task<DeviceGetDto> UpdateDeviceAsync(DevicePutDto deviceDto);
    Task<bool> RemoveDeviceAsync(Guid deviceId);
    Task<bool> RemoveDeviceRangeAsync(IEnumerable<Guid> deviceIds);
    Task<bool> DeviceExistsAsync(Guid deviceId);
}