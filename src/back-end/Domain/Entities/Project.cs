namespace Domain.Entities;

public class Project : IEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<UserInProject>? Participants { get; set; }
    public IEnumerable<Device>? Devices { get; set; }
}