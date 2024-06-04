using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;

public partial class Document
{

    public Document()
    {
        FileInfo = new ValueObjects.FileInfo();
    }
    
    public Document(string fileName, string fileUrl, int folderId)
    {
        FileInfo = new ValueObjects.FileInfo(fileName, fileUrl);
        FolderId = folderId;
    }
    
    public int Id { get; }
    public ValueObjects.FileInfo FileInfo { get; private set; }
    
    public Folder Folder { get; set; }
    public int FolderId { get; private set; }

    public string FileName => FileInfo.FileName;

    public string FileUrl => FileInfo.FileUrl;
}