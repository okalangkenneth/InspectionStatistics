using System;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections
{
    public class DepartmentInspectionListVm
    {
        public Guid DepartmentId { get; set; }
        public string InspectionType { get; set; }
        public ICollection<DepartmentInspectionDto> Inspections { get; set; }
    }
}
