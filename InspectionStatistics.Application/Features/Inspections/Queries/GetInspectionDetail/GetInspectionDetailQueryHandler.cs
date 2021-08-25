using AutoMapper;
using InspectionStatistics.Application.Features.Inspections.GetInspectionDetail;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionDetail;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections
{
    public class GetInspectionDetailQueryHandler : IRequestHandler<GetInspectionDetailQuery, InspectionDetailVm>
    {
        private readonly IAsyncRepository<Inspection> _inspectionRepository;
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public GetInspectionDetailQueryHandler(IMapper mapper, IAsyncRepository<Inspection> inspectionRepository, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<InspectionDetailVm> Handle(GetInspectionDetailQuery request, CancellationToken cancellationToken)
        {
            var inspection = await _inspectionRepository.GetByIdAsync(request.Id);
            var inspectionDetailDto = _mapper.Map<InspectionDetailVm>(@inspection);
            
            var department = await _departmentRepository.GetByIdAsync(inspection.DepartmentId);

            //if (department == null)
            //{
            //    throw new NotFoundException(nameof(Inspection), request.Id);
            //}
            inspectionDetailDto.Department = _mapper.Map<DepartmentDto>(department);

            return inspectionDetailDto;
        }
    }
}
