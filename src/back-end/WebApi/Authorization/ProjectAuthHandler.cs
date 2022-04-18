using Microsoft.AspNetCore.Authorization;
using Domain.Entities;

namespace WebApi.Authorization;

public class ProjectAuthHandler : AuthorizationHandler<ProjectParticipantRequirement, Project>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        ProjectParticipantRequirement requirement,
        Project resource)
    {
        throw new NotImplementedException();
    }
}