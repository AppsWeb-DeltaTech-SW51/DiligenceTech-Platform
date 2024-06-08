using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class AgentRepository(AppDbContext context) : BaseRepository<Agent>(context), IAgentRepository
{
    public Task<Agent?> FindByCodeAsync(string code)
    {
        return Context.Set<Agent>().Where(a => a.Code == code).FirstOrDefaultAsync();
    }
}