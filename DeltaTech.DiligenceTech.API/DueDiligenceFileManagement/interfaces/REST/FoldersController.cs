using System.Net.Mime;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DeltaTech.DiligenceTech.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/folders")]
[Produces(MediaTypeNames.Application.Json)]
public class FoldersController(IFolderCommandService folderCommandService, IFolderQueryService folderQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFolder(CreateFolderResource resource)
    {
        var createFolderCommand = CreateFolderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var folder = await folderCommandService.Handle(createFolderCommand);
        if (folder is null) return BadRequest();
        var folderResource = FolderResourceFromEntityAssembler.ToResourceFromEntity(folder);
        return CreatedAtAction(nameof(GetFolderById), new {folderId = folderResource.Id}, folderResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllFolders()
    {
        var getAllFoldersQuery = new GetAllFoldersQuery();
        var folders = await folderQueryService.Handle(getAllFoldersQuery);
        var folderResource = folders.Select(FolderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(folderResource);
    }
    
    [HttpGet("{folderId:int}")]
    public async Task<IActionResult> GetFolderById(int folderId)
    {
        var getFolderByIdQuery = new GetFolderByIdQuery(folderId);
        var folder = await folderQueryService.Handle(getFolderByIdQuery);
        if (folder == null) return NotFound();
        var folderResource = FolderResourceFromEntityAssembler.ToResourceFromEntity(folder);
        return Ok(folderResource);
    }

    [HttpPost("{folderId}/documents")]
    public async Task<IActionResult> CreateDocument([FromRoute] int folderId,[FromBody] CreateDocumentResource resource)
    {
        var createDocumentCommand = new CreateDocumentCommand(folderId, resource.fileName, resource.fileUrl);
        var result = await folderCommandService.Handle(createDocumentCommand);
        if (result == null)
        {
            return BadRequest();
        }

        var getDocumentByFolderIdAndDocumentName = new GetDocumentByFolderIdWithDocumentName(folderId, resource.fileName);
        var document = await folderQueryService.Handle(getDocumentByFolderIdAndDocumentName);
        if (document is null)
        {
            return BadRequest();
        }
        var documentResource = DocumentResourceFromEntityAssembler.ToResourceFromEntity(document);
        return CreatedAtAction(nameof(GetDocument), new { folderId = documentResource.folderId, documentName = documentResource.fileName }, documentResource);

    }

    [HttpGet("{folderId}/documents/{documentName}")]
    public async Task<IActionResult> GetDocument([FromRoute] int folderId, [FromRoute] string documentName)
    {
        var getDocumentByFolderIdAndDocumentName = new GetDocumentByFolderIdWithDocumentName(folderId, documentName);
        var document = await folderQueryService.Handle(getDocumentByFolderIdAndDocumentName);
        if (document is null)
        {
            return NotFound();
        }
        var documentResource = DocumentResourceFromEntityAssembler.ToResourceFromEntity(document);
        return Ok(documentResource);
    }
    
}
