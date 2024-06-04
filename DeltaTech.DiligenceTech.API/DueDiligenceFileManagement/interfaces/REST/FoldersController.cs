using System.Net.Mime;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Services;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Resources;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
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
        return CreatedAtAction(nameof(GetFolderById), new {fileId = folderResource.Id}, folderResource);
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
    
}