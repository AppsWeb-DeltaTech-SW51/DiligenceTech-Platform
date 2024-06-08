using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.ValueObjects;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.ACL.Services;

public class FoldersContextFacade(IFolderCommandService folderCommandService, IFolderQueryService folderQueryService): IFoldersContextFacade
{
    public async Task<int> CreateFolder(string name, EFolderStatus buyStatus, EFolderStatus sellStatus, bool obligatory,
        EFolderPriority priority)
    {
        var createFolderCommand = new CreateFolderCommand(name, buyStatus, sellStatus, obligatory, priority);
        var folder = await folderCommandService.Handle(createFolderCommand);
        return folder?.Id ?? 0;
    }
    
    
    public async Task<int> FetchFolderIdByname(string name)
    {
        var getFolderByNameQuery = new GetFolderByNameQuery(name);
        var folder = await folderQueryService.Handle(getFolderByNameQuery);
        return folder?.Id ?? 0;
    }
    
}