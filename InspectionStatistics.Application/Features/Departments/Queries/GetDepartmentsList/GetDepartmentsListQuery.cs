using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList;
using MediatR;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetCategoriesList
{
    public class GetDepartmentsListQuery : IRequest<List<DepartmentListVm>>
    {
    }
}
