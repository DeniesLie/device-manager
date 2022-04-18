using Domain.Enums;

namespace Application.Dto;

public class DevicePutDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DeviceType Type { get; set; }
}