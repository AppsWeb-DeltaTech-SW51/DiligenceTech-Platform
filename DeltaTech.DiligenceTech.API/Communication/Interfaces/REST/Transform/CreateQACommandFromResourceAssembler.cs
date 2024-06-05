using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Transform;

public static class CreateQACommandFromResourceAssembler
{
    public static CreateQACommand ToCommandfromResources(CreateQAResource resource)
    {
        return new CreateQACommand(resource.content);
    }
}