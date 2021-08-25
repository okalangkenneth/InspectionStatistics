using System;

namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport
{
    public class InspectionExportDto
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public DateTime Date { get; set; }
    }
}
