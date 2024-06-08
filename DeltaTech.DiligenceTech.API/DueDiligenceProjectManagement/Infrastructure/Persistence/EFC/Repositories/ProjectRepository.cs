using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Infrastructure.Persistence.EFC.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    public Task<Project?> FindByCodeAsync(string code)
    {
        return Context.Set<Project>().Where(a => a.Code == code).FirstOrDefaultAsync();
    }
}