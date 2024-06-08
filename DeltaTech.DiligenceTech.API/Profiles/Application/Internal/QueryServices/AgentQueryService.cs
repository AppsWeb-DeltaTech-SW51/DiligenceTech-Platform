using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Services;

namespace DeltaTech.DiligenceTech.API.Profiles.Application.Internal.QueryServices;

public class AgentQueryService(IAgentRepository agentRepository) : IAgentQueryService
{
    public async Task<IEnumerable<Agent>> Handle(GetAllAgentsQuery query) => await agentRepository.ListAsync();

    public async Task<Agent?> Handle(GetAgentByCodeQuery query) => await agentRepository.FindByCodeAsync(query.Code);

    public async Task<Agent?> Handle(GetAgentByIdQuery query) => await agentRepository.FindByIdAsync(query.Id);
}