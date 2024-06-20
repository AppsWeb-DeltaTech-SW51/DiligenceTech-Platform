using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Services;

namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.ACL.Services;

public class AgentsContextFacade(IAgentCommandService agentCommandService, IAgentQueryService agentQueryService) : IAgentsContextFacade
{
    public async Task<string> CreateAgent(string code, string email, string username, string password, string image)
    {
        
        var createProfileCommand = new CreateAgentCommand(code, email, username, password, image);
        var agent = await agentCommandService.Handle(createProfileCommand);
        return agent?.Code ?? "";
    }

    public async Task<string> FetchAgentIdByCode(string code)
    {
        var getAgentByCodeQuery = new GetAgentByCodeQuery(code);
        var agent = await agentQueryService.Handle(getAgentByCodeQuery);
        return agent?.Code ?? "";
    }
}

