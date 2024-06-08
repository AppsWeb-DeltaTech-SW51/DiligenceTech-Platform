using System.ComponentModel.DataAnnotations.Schema;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;

public partial class Folder
{
    public int Id { get; }
    public string Name { get; private set; }
    public EFolderStatus BuyStatus { get; private set; }
    public EFolderStatus SellStatus { get; private set; }
    public bool Obligatory { get; private set; }
    public EFolderPriority Priority { get; private set; }

    public Folder Parent { get; set; }
    
    public int? ParentId { get; private set; }
    
    public ICollection<Document> Documents { get; }

    public Folder(string name, EFolderStatus buyStatus, EFolderStatus sellStatus, bool obligatory, EFolderPriority priority)
    {
        Name = name;
        BuyStatus = buyStatus;
        SellStatus = sellStatus;
        Obligatory = obligatory;
        Priority = priority;
        Documents = new List<Document>();
    }
    
    public void AssignParent(Folder parent)
    {
        Parent = parent;
        ParentId = parent?.Id;
    }

    public Folder(CreateFolderCommand command)
    {
        Name = command.Name;
        BuyStatus = command.BuyStatus;
        SellStatus = command.SellStatus;
        Obligatory = command.Obligatory;
        Priority = command.Priority;
        Documents = new List<Document>();
    }
}
