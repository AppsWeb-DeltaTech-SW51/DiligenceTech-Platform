namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.ACL;

public interface IProjectsContextFacade
{
    Task<string> CreateProject(string code, string name, bool confirmed);

    Task<string> FetchProjectIdByCode(string code);
}