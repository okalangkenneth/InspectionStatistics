using MediatR;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class GetDepartmentsListQuery : IRequest<List<DepartmentListVm>>
    {
    }
}
