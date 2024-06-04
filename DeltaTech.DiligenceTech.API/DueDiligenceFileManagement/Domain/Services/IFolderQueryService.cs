using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Queries;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;

public interface IFolderQueryService
{
    Task<IEnumerable<Folder>> Handle(GetAllFoldersQuery query);
    Task<Folder?> Handle(GetFolderByIdQuery query);
    Task<Folder?> Handle(GetFolderByNameQuery query);
}