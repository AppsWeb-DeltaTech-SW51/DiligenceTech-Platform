using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Transform;

public static class ProjectResourceFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Project entity)
    {
        return new ProjectResource(entity.Code, entity.Name, entity.Confirmed);
    }
}
