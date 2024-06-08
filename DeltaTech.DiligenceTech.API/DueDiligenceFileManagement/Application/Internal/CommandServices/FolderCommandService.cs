using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Repositories;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.Shared.Domain.Repositories;

namespace DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Application.Internal.CommandServices;

public class FolderCommandService(IFolderRepository folderRepository, IUnitOfWork unitOfWork) : IFolderCommandService
{
 public async Task<Folder?> Handle(CreateFolderCommand command)
 {
   var folder = new Folder(command);
   try
   {
       await folderRepository.AddAsync(folder);
       await unitOfWork.CompleteAsync();
       return folder;
   }
   catch (Exception e)
   {
       Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
       return null;
   }
 }
}