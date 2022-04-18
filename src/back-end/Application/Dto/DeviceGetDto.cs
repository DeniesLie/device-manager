using Domain.Enums;

namespace Application.Dto;

public class DeviceGetDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DeviceType Type { get; set; }
    public DeviceState State { get; set; }
    public DateTime AddingToProjectDateTime { get; set; }
    public OSDto? OS { get; set; }
    public string? ProjectId { get; set; }
}