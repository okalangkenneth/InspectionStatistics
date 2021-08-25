using AutoMapper;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IMapper mapper, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var createDepartmentCommandResponse = new CreateDepartmentCommandResponse();

            var validator = new CreateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createDepartmentCommandResponse.Success = false;
                createDepartmentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDepartmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createDepartmentCommandResponse.Success)
            {
                var department = new Department() { InspectionType = request.InspectionType };
                department = await _departmentRepository.AddAsync(department);
                createDepartmentCommandResponse.Department = _mapper.Map<CreateDepartmentDto>(department);
            }

            return createDepartmentCommandResponse;
        }
    }
}
