using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.Profiles.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.REST.Transform;

public static class CreateAgentCommandFromResourceAssembler
{
    public static CreateAgentCommand ToCommandFromResource(AgentResource resource)
    {
        return new CreateAgentCommand(resource.Id, resource.Email, resource.Username, resource.Password,
            resource.Image);
    }
}