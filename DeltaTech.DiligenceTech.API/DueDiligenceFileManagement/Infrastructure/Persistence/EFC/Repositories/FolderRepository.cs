using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Infrastructure.Persistence.EFC.Repositories;

public class FolderRepository(AppDbContext context) : BaseRepository<Folder>(context), IFolderRepository
{
    public Task<Folder?> FindFolderByNameAsync(string folderName)
    {
        return Context.Set<Folder>().Where(f => f.Name == folderName).FirstOrDefaultAsync();
    }
}