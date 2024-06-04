using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.QueryServices;

public class FolderQueryService (IFolderRepository folderRepository) : IFolderQueryService
{
    public async Task<IEnumerable<Folder>> Handle(GetAllFoldersQuery query)
    {
        return await folderRepository.ListAsync();
    }

    public async Task<Folder?> Handle(GetFolderByIdQuery query)
    {
        return await folderRepository.FindByIdAsync(query.FolderId);
    }

    public async Task<Folder?> Handle(GetFolderByNameQuery query)
    {
        return await folderRepository.FindFolderByNameAsync(query.Name);
    }
}