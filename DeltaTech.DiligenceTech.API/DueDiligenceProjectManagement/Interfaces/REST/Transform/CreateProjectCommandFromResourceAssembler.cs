using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Transform;

public static class CreateProjectCommandFromResourceAssembler
{
    public static CreateProjectCommand ToCommandFromResourceConfirmed(CreateProjectResource resource)
    {
        return new CreateProjectCommand(resource.Id, resource.Name, true);
    }
    
    public static CreateProjectCommand ToCommandFromResourcePending(CreateProjectResource resource)
    {
        return new CreateProjectCommand(resource.Id, resource.Name, false);
    }
}