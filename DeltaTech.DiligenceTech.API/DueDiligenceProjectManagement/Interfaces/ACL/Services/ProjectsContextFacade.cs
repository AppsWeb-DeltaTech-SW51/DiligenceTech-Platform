using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.ACL.Services;

public class ProjectsContextFacade(IProjectCommandService projectCommandService, IProjectQueryService projectQueryService) : IProjectsContextFacade
{
    public async Task<string> CreateProject(string code, string name, bool confirmed)
    {
        var createProjectCommand = new CreateProjectCommand(code, name, confirmed);
        var project = await projectCommandService.Handle(createProjectCommand);
        return project?.Code ?? "";
    }

    public async Task<string> FetchProjectIdByCode(string code)
    {
        var getProjectByCodeQuery = new GetProjectByCodeQuery(code);
        var project = await projectQueryService.Handle(getProjectByCodeQuery);
        return project?.Code ?? "";
    }
}