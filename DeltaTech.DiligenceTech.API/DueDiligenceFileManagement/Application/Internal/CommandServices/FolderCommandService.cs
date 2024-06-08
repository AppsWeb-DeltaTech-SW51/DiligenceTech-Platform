using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;
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
       Console.WriteLine($"An error occurred while creating the folder: {e.Message}");
       return null;
   }
 }

 public async Task<Folder?> Handle(CreateDocumentCommand command) {
    // Verificar si la carpeta existe
    var folder = await folderRepository.FindByIdAsync(command.folderId);
    if (folder == null)
    {
        throw new InvalidOperationException($"Folder with Id {command.folderId} not found");
    }

    // Crear el documento
    var document = new Document(command);

    try
    {
        // Agregar el documento al repositorio
        await folderRepository.AddAsync(folder);
        await unitOfWork.CompleteAsync();
        
        // Agregar el documento a la lista de documentos de la carpeta
        folder.Documents.Add(document);

        // Actualizar la carpeta en el repositorio
        //await folderRepository.UpdateAsync(folder);
        await unitOfWork.CompleteAsync();

        return folder;
    }
    catch (Exception e)
    {
        Console.WriteLine($"An error occurred while creating the document: {e.Message}");
        throw; // Re-lanzar la excepción
    }
 }
}

