using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<Project?> FindByCodeAsync(string code);
}