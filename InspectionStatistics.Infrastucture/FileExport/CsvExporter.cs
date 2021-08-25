
using CsvHelper;
using InspectionStatistics.Application.Contracts.Infrastructure;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport;
using System.Collections.Generic;
using System.IO;

namespace InspectionStatistics.Infrastucture
{
    public class CsvExporter : ICsvExporter
    {
        

        public byte[] ExportInspectionsToCsv(List<InspectionExportDto> inspectionExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                
                using var csvWriter = new CsvWriter(streamWriter); 
                csvWriter.WriteRecords(inspectionExportDtos);
            }

            return memoryStream.ToArray();
        }
    }


}
