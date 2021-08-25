using InspectionStatistics.Domain.Common;
using System;

namespace InspectionStatistics.Domain.Entities
{
    public class Inspection : AuditableEntity
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public int Price { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
