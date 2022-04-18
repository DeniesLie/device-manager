namespace Domain.Entities;

public class Project : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDateTime { get; set; }

    public List<ProjectMembership> Memberships { get; set; } = new();
    public IEnumerable<Device>? Devices { get; set; }
}