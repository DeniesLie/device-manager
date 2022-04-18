namespace Application.Dto;

public class ProjectPutDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}