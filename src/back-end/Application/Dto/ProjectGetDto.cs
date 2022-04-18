namespace Application.Dto;

public class ProjectGetDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDateTime { get; set; }
    public IEnumerable<ProjectMembershipDto>? Memberships { get; set; }
    public IEnumerable<DeviceGetDto>? Devices { get; set; }
}