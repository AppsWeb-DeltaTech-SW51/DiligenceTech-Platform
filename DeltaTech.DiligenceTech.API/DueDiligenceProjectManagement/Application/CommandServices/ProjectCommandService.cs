using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Application.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository, IUnitOfWork unitOfWork) : IProjectCommandService
{
    public async Task<Project?> Handle(CreateProjectCommand command)
    {
        var project = new Project(command);
        try
        {
            await projectRepository.AddAsync(project);
            await unitOfWork.CompleteAsync();
            return project;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the project: {e.Message}");
            return null;
        }
    }
}