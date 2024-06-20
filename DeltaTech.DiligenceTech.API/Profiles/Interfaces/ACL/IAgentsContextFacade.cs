namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.ACL;

public interface IAgentsContextFacade
{
    Task<string> CreateAgent(string code, string email, string username, string password, string image);

    Task<string> FetchAgentIdByCode(string code);
}