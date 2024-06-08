namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;

public record CreateDocumentCommand(int folderId, string fileName, string fileUrl);
