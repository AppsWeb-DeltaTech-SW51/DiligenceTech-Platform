using System.Net.Mime;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Queries;
using DeltaTech.DiligenceTech.API.Communication.Domain.Services;
using DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Resources;
using DeltaTech.DiligenceTech.API.Communication.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class QAController(IQACommandService qaCommandService,IQAQueryService qaQueryService) :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateQA (CreateQAResource resource)
    {
        var createQACommand = CreateQACommandFromResourceAssembler.ToCommandfromResources(resource);
        var qa = await qaCommandService.Handle(createQACommand);
        if (qa is null) return BadRequest();
        var qaResource = QAResourceFromEntityAssembler.ToResourceFromEntity(qa);
        return CreatedAtAction(nameof(GetQAById), new {qaId = qaResource.Id}, qaResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQAS()
    {
        var getAllQAQuery = new GetAllQASQuery();
        var qas = await qaQueryService.Handle(getAllQAQuery);
        var qaResource = qas.Select(QAResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(qaResource);
    }

    [HttpGet("{qaId:int}")]
    public async Task<IActionResult> GetQAById(int qaId)
    {
        var getQAByIdQuery = new GetQAByIdQuery(qaId);
        var qa = await qaQueryService.Handle(getQAByIdQuery);
        if (qa == null) return NotFound();
        var qaResource = QAResourceFromEntityAssembler.ToResourceFromEntity(qa);
        return Ok(qaResource);
    }
}