using AutoMapper;
using InspectionStatistics.Application.Contracts.Infrastructure;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsExport
{
    public class GetInspectionsExportQueryHandler : IRequestHandler<GetInspectionsExportQuery, InspectionExportFileVm>
    {
        private readonly IAsyncRepository<Inspection> _inspectionRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetInspectionsExportQueryHandler(IMapper mapper, IAsyncRepository<Inspection> inspectionRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
            _csvExporter = csvExporter;
        }

        public async Task<InspectionExportFileVm> Handle(GetInspectionsExportQuery request, CancellationToken cancellationToken)
        {
            var allInspections = _mapper.Map<List<InspectionExportDto>>((await _inspectionRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExporter.ExportInspectionsToCsv(allInspections);

            var inspectionExportFileDto = new InspectionExportFileVm() { ContentType = "text/csv", Data = fileData, InspectionExportFileName = $"{Guid.NewGuid()}.csv" };

            return inspectionExportFileDto;
        }
    }
}
