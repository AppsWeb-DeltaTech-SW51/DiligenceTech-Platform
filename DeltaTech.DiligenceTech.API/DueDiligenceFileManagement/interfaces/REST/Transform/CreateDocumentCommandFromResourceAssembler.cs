using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;

using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;

public static class CreateDocumentCommandFromResourceAssembler 
{
    public static CreateDocumentCommand ToCommandFromResource(int folderId, CreateDocumentResource resource) {
      return new CreateDocumentCommand(folderId, resource.fileName, resource.fileUrl);
    }
}
