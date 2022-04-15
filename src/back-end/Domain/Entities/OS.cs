using Domain.Enums;

namespace Domain.Entities;

public class OS
{
    public OSType OSType { get; set; }
    public string? OSVersion { get; set; }
}