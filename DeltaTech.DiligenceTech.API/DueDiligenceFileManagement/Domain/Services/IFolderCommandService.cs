using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;

public interface IFolderCommandService
{
    Task<Folder?> Handle(CreateFolderCommand command);
}