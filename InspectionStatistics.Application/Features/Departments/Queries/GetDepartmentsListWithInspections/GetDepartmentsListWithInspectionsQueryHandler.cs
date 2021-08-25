using AutoMapper;
using InspectionStatistics.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections
{
    public class GetDepartmentsListWithInspectionsQueryHandler : IRequestHandler<GetDepartmentsListWithInspectionsQuery, List<DepartmentInspectionListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentsListWithInspectionsQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentInspectionListVm>> Handle(GetDepartmentsListWithInspectionsQuery request, CancellationToken cancellationToken)
        {
            var list = await _departmentRepository.GetDepartmentsWithInspections(request.IncludeHistory);
            return _mapper.Map<List<DepartmentInspectionListVm>>(list);
        }
    }
}
