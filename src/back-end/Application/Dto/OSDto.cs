using Domain.Enums;

namespace Application.Dto;

public class OSDto
{
    public int Id { get; set; }
    public OSType Type { get; set; }
    public string? Version { get; set; }
}