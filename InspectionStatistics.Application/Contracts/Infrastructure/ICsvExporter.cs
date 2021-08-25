using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportInspectionsToCsv(List<InspectionExportDto> inspectionExportDtos);
    }
}
