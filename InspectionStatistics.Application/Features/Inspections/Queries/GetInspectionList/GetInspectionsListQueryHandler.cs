using AutoMapper;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionList;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsList;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections
{
    public class GetInspectionsListQueryHandler : IRequestHandler<GetInspectionsListQuery, List<InspectionListVm>>
    {
        private readonly IAsyncRepository<Inspection> _inspectionRepository;
        private readonly IMapper _mapper;

        public GetInspectionsListQueryHandler(IMapper mapper, IAsyncRepository<Inspection> inspectionRepository)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
        }

        public async Task<List<InspectionListVm>> Handle(GetInspectionsListQuery request, CancellationToken cancellationToken)
        {
            var allInspections = (await _inspectionRepository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<InspectionListVm>>(allInspections);
        }
    }
}
