using Domain.Entities;
using Domain.Enums;

namespace Application.Dto;

public class DevicePostDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DeviceType Type { get; set; }
    public DeviceState State { get; set; }
    public OSDto? OS { get; set; }
    public Guid ProjectId { get; set; }
}