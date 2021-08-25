using AutoMapper;
using InspectionStatistics.Application.Exceptions;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections.Commands.UpdateInspection
{
    public class UpdateInspectionCommandHandler : IRequestHandler<UpdateInspectionCommand>
    {
        private readonly IAsyncRepository<Inspection> _inspectionRepository;
        private readonly IMapper _mapper;

        public UpdateInspectionCommandHandler(IMapper mapper, IAsyncRepository<Inspection> inspectionRepository)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
        }

        public async Task<Unit> Handle(UpdateInspectionCommand request, CancellationToken cancellationToken)
        {

            var inspectionToUpdate = await _inspectionRepository.GetByIdAsync(request.InspectionId);

            if (inspectionToUpdate == null)
            {
                throw new NotFoundException(nameof(Inspection), request.InspectionId);
            }

            var validator = new UpdateInspectionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, inspectionToUpdate, typeof(UpdateInspectionCommand), typeof(Inspection));

            await _inspectionRepository.UpdateAsync(inspectionToUpdate);

            return Unit.Value;
        }
    }
}