namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.ACL;

public interface IAgentsContextFacade
{
    Task<int> CreateAgent(string code, string email, string username, string password, string image);

    Task<int> FetchAgentIdByCode(string code);
}