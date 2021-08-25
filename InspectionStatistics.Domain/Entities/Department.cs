using InspectionStatistics.Domain.Common;
using System;
using System.Collections.Generic;

namespace InspectionStatistics.Domain.Entities
{
    public class Department: AuditableEntity
    {
        public Guid DepartmentId { get; set; }
        public string InspectionType { get; set; }
        public ICollection<Inspection> Inspections { get; set; }
    }
}
