using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.QueryServices;

public class ProjectQueryService(IProjectRepository projectRepository) : IProjectQueryService
{
    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query) => await projectRepository.ListAsync();

    public async Task<Project?> Handle(GetProjectByIdQuery query) => await projectRepository.FindByIdAsync(query.Id);
    
    public async Task<Project?> Handle(GetProjectByCodeQuery query) => await projectRepository.FindByCodeAsync(query.Code);
}