using Domain.Enums;

namespace Domain.Entities;

public class OS : IEntity
{
    public int Id { get; set; }
    public OSType OSType { get; set; }
    public string? OSVersion { get; set; }

    public List<Device> Devices { get; set; } = new();
}