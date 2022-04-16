namespace Domain.Entities;

public class Device : IEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public int OSId { get; set; }
    public OS? OS { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}