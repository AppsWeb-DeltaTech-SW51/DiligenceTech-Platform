using System.Net.Mime;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Resources;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/projects")]
[Produces(MediaTypeNames.Application.Json)]
public class ProjectsController(IProjectCommandService projectCommandService, IProjectQueryService projectQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectResource resource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResourceConfirmed(resource);
        var project = await projectCommandService.Handle(createProjectCommand);
        if (project is null) return BadRequest();
        
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        
        // Aquí debes asegurarte de pasar el código del proyecto recién creado
        return CreatedAtAction(nameof(GetProjectByCode), new { projectCode = project.Code }, projectResource);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var getAllProjectsQuery = new GetAllProjectsQuery();
        var projects = await projectQueryService.Handle(getAllProjectsQuery);
        var projectsResources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(projectsResources);
    }

    [HttpGet("{projectCode}")]
    public async Task<IActionResult> GetProjectByCode(string projectCode)
    {
        var getProjectByCodeQuery = new GetProjectByCodeQuery(projectCode);
        var project = await projectQueryService.Handle(getProjectByCodeQuery);
        if (project is null) return NotFound();
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }
}
