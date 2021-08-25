using System;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class DepartmentListVm
    {
        public Guid DepartmentId { get; set; }
        public string InspectionType { get; set; }
    }
}
