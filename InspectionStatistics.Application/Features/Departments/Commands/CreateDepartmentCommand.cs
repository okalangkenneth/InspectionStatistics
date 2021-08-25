using MediatR;

namespace InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand: IRequest<CreateDepartmentCommandResponse>
    {
        public string InspectionType { get; set; }
    }
}
