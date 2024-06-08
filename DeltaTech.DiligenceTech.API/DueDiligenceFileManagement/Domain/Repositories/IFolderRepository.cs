using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;

public interface IFolderRepository : IBaseRepository<Folder>
{
    Task<Folder?> FindFolderByNameAsync(string folderName);
}
