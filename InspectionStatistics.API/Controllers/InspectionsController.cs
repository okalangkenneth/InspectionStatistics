using InspectionStatistics.Api.Utility;
using InspectionStatistics.Application.Features.Inspections;
using InspectionStatistics.Application.Features.Inspections.Commands.CreateInspection;
using InspectionStatistics.Application.Features.Inspections.Commands.DeleteInspection;
using InspectionStatistics.Application.Features.Inspections.Commands.UpdateInspection;
using InspectionStatistics.Application.Features.Inspections.GetInspectionDetail;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionDetail;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport;
using InspectionStatistics.Application.Features.Inspectons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.API.Controllers
{

}
[ApiController]
[Route("api/[controller]")]
public class InspectionsController : Controller
{
    private readonly IMediator _mediator;

    public InspectionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllInspections")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<InspectionListVm>>> GetAllInspections()
    {
        var dtos = await _mediator.Send(new GetInspectionsListQuery());
        return Ok(dtos);
    }

    [HttpGet("{id}", Name = "GetInspectionById")]
    public async Task<ActionResult<InspectionDetailVm>> GetInspectionById(Guid id)
    {
        var getInspectionDetailQuery = new GetInspectionDetailQuery() { Id = id };
        return Ok(await _mediator.Send(getInspectionDetailQuery));
    }

    [HttpPost(Name = "AddInspection")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateInspectionCommand createInspectionCommand)
    {
        var id = await _mediator.Send(createInspectionCommand);
        return Ok(id);
    }

    [HttpPut(Name = "UpdateInspection")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateInspectionCommand updateInspectionCommand)
    {
        await _mediator.Send(updateInspectionCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteInspection")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteInspectionCommand = new DeleteInspectionCommand() { InspectionId = id };
        await _mediator.Send(deleteInspectionCommand);
        return NoContent();
    }

    [HttpGet("export", Name = "ExportInspections")]
    [FileResultContentType("text/csv")]
    public async Task<FileResult> ExportInspections()
    {
        var fileDto = await _mediator.Send(new GetInspectionsExportQuery());

        return File(fileDto.Data, fileDto.ContentType, fileDto.InspectionExportFileName);
    }
}
