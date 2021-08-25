namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport
{
    public class InspectionExportFileVm
    {
        public string InspectionExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}