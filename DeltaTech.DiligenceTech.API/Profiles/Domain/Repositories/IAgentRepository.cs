using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;

public interface IAgentRepository : IBaseRepository<Agent>
{
    Task<Agent?> FindByCodeAsync(string code);
}