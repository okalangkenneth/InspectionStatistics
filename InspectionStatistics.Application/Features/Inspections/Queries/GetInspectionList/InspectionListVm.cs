using System;

namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionList
{
    public class InspectionListVm
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public DateTime Date { get; set; }
        
    }
}
