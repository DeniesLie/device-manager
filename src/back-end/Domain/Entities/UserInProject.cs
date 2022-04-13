using System.Security.Principal;
using Domain.Enums;

namespace Domain.Entities;

public class UserInProject : IEntity
{
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public ProjectRole ProjectRole { get; set; }
}