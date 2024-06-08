using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces;

public interface IFoldersContextFacade
{
    Task<int> CreateFolder(string name, EFolderStatus buyStatus, EFolderStatus sellStatus, bool obligatory,
        EFolderPriority priority);
    
    Task<int> FetchFolderIdByname(string name);
}