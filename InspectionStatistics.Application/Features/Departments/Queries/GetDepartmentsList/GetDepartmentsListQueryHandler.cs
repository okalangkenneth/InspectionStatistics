using AutoMapper;
using InspectionStatistics.Application.Features.Departments.Queries.GetCategoriesList;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class GetDepartmentsListQueryHandler : IRequestHandler<GetDepartmentsListQuery, List<DepartmentListVm>>
    {
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsListQueryHandler(IMapper mapper, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentListVm>> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var allDepartments = (await _departmentRepository.ListAllAsync()).OrderBy(x => x.InspectionType);
            return _mapper.Map<List<DepartmentListVm>>(allDepartments);
        }
    }
}
