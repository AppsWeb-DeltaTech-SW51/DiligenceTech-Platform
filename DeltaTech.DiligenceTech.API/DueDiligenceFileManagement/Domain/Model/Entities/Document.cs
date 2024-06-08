using System.ComponentModel.DataAnnotations.Schema;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;

public partial class Document
{ 
    public int Id {get;}
    public int folder_Id {get; private set;}
    public string file_Name {get; private set;}
    public string file_Url {get; private set;}

    public Folder Folder {get; private set;}

    public Document()
    {
        folder_Id = 0;
        file_Name = "";
        file_Url = "";
    }
    
    public Document(int folderId, string fileName, string fileUrl)
    {
        folder_Id = folderId;
        file_Name = fileName;
        file_Url = fileUrl;
    }
    
    public Document(CreateDocumentCommand command) {
        folder_Id = command.folderId;
        file_Name = command.fileName;
        file_Url = command.fileUrl;
    }
}
