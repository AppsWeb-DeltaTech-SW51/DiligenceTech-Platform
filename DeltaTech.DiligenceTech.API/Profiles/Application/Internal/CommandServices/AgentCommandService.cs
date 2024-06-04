using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Services;
using DeltaTech.DiligenceTech.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.Profiles.Application.Internal.CommandServices;

public class AgentCommandService(IAgentRepository agentRepository, IUnitOfWork unitOfWork) : IAgentCommandService
{
    public async Task<Agent?> Handle(CreateAgentCommand command)
    {
        var agent = new Agent(command);
        try
        {
            await agentRepository.AddAsync(agent);
            await unitOfWork.CompleteAsync();
            return agent;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the agent: {e.Message}");
            return null;
        }
    }
}