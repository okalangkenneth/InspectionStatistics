using MediatR;

namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport
{
    public class GetInspectionsExportQuery: IRequest<InspectionExportFileVm>
    {
    }
}
