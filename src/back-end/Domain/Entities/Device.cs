namespace Domain.Entities;

public class Device : IEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public OS? OS { get; set; }
    
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}