using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Queries;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;

public interface IProjectQueryService
{
    Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query);

    Task<Project?> Handle(GetProjectByIdQuery query);

    Task<Project?> Handle(GetProjectByCodeQuery query);
}