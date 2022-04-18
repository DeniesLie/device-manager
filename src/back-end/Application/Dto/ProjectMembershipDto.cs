using Domain.Enums;

namespace Application.Dto;

public class ProjectMembershipDto
{
    public UserDto? UserDto { get; set; }
    public string? ProjectId { get; set; }
    public ProjectRole ProjectRole { get; set; }
}