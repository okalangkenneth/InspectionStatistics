using FluentValidation;

namespace InspectionStatistics.Application.Features.Inspections.Commands.UpdateInspection
{
    public class UpdateInspectionCommandValidator : AbstractValidator<UpdateInspectionCommand>
    {
        public UpdateInspectionCommandValidator()
        {
            RuleFor(p => p.InspectionType)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyInspectionType} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .GreaterThan(0);
        }
    }
}
