using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;

public static class FolderResourceFromEntityAssembler
{
    public static FolderResource ToResourceFromEntity(Folder entity)
    {
        return new FolderResource(entity.Id, entity.BuyStatus, entity.SellStatus, entity.Obligatory, entity.Priority);
    }
    
}