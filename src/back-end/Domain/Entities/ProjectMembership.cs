using System.Security.Principal;
using Domain.Enums;

namespace Domain.Entities;

public class ProjectMembership : IEntity
{
    public string?  UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

    public ProjectRole ProjectRole { get; set; }
}