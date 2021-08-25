using FluentValidation;

namespace InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator: AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(p => p.InspectionType)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyInspectionType} must not exceed 10 characters.");
        }
    }
}
