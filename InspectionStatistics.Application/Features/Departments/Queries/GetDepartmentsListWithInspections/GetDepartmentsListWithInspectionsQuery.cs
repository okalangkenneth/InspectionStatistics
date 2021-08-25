using MediatR;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections
{
    public class GetDepartmentsListWithInspectionsQuery: IRequest<List<DepartmentInspectionListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
