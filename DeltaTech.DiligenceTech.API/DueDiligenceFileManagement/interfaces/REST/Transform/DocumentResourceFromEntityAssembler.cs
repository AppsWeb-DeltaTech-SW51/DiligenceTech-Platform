using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;

using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;

public static class DocumentResourceFromEntityAssembler
{
    public static DocumentResource ToResourceFromEntity(Document entity) {
        return new DocumentResource(entity.folder_Id, entity.file_Name, entity.file_Url);
    }
}
