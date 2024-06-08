using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.Profiles.Domain.Services;

public interface IAgentCommandService
{
    Task<Agent?> Handle(CreateAgentCommand command);
}