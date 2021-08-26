using InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentListVm>>> GetAllDepartments()
        {
            var dtos = await _mediator.Send(new GetDepartmentsListQuery());
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("allwithinspections", Name = "GetDepartmentsWithInspections")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentInspectionListVm>>> GetDepartmentsWithInspections(bool includeHistory)
        {
            GetDepartmentsListWithInspectionsQuery getDepartmentsListWithInspectionsQuery = new GetDepartmentsListWithInspectionsQuery() { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getDepartmentsListWithInspectionsQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddDepartment")]
        public async Task<ActionResult<CreateDepartmentCommandResponse>> Create([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            var response = await _mediator.Send(createDepartmentCommand);
            return Ok(response);
        }
    }
}
