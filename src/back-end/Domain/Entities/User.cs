namespace Domain.Entities;

public class User : IEntity
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public IEnumerable<UserInProject>? Projects { get; set; }
}