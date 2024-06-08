using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Queries;

namespace DeltaTech.DiligenceTech.API.Profiles.Domain.Services;

public interface IAgentQueryService
{
    Task<IEnumerable<Agent>> Handle(GetAllAgentsQuery query);

    Task<Agent?> Handle(GetAgentByCodeQuery query);

    Task<Agent?> Handle(GetAgentByIdQuery query);
}