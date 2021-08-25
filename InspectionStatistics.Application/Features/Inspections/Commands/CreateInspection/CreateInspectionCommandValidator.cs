using FluentValidation;
using InspectionStatistics.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections.Commands.CreateInspection
{
    public class CreateInspectionCommandValidator : AbstractValidator<CreateInspectionCommand>
    {
        private readonly IInspectionRepository _inspectionRepository;
        public CreateInspectionCommandValidator(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;

            RuleFor(p => p.InspectionType)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyInspectionType} must not exceed 50 characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(InspectionInspectionTypeAndDateUnique)
                .WithMessage("An inspection with the same inspection type and date already exists.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyInspectionType} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> InspectionInspectionTypeAndDateUnique(CreateInspectionCommand e, CancellationToken token)
        {
            return !(await _inspectionRepository.IsInspectionInspectionTypeAndDateUnique(e.InspectionType, e.Date));
        }
    }
}
