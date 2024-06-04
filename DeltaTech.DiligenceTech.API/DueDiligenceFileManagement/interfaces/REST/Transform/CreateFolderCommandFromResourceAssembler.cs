using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;

public static class CreateFolderCommandFromResourceAssembler
{
    public static CreateFolderCommand ToCommandFromResource(CreateFolderResource resource)
    {
        return new CreateFolderCommand(resource.Name, resource.BuyStatus, resource.SellStatus, resource.Obligatory,
            resource.Priority);
    }
}