using InspectionStatistics.Application.Responses;

namespace InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandResponse: BaseResponse
    {
        public CreateDepartmentCommandResponse(): base()
        {

        }

        public CreateDepartmentDto Department { get; set; }
    }
}