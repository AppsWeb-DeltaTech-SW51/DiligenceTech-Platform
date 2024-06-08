using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;

public interface IProjectCommandService
{
    Task<Project?> Handle(CreateProjectCommand command);
}