using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.REST.Transform;

public static class AgentResourceFromEntityAssembler
{
    public static AgentResource ToResourceFromEntity(Agent entity)
    {
        return new AgentResource(entity.Code, entity.Email, entity.Username, entity.Password, entity.Image);
    }
}