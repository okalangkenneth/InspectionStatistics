using System;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections
{
    public class DepartmentInspectionDto
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public int Price { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
