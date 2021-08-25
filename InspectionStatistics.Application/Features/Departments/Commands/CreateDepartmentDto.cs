using System;

namespace InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string InspectionType { get; set; }
    }
}
