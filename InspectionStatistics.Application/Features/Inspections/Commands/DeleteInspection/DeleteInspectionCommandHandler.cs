using AutoMapper;
using InspectionStatistics.Application.Exceptions;
using InspectionStatistics.Application.Features.Inspections.Commands.DeleteEvent;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections.Commands.DeleteInspection
{
    public class DeleteInspectionCommandHandler : IRequestHandler<DeleteInspectionCommand>
    {
        private readonly IAsyncRepository<Inspection> _inspectionRepository;
        private readonly IMapper _mapper;
        
        public DeleteInspectionCommandHandler(IMapper mapper, IAsyncRepository<Inspection> inspectionRepository)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
        }

        public async Task<Unit> Handle(DeleteInspectionCommand request, CancellationToken cancellationToken)
        {
            var inspectionToDelete = await _inspectionRepository.GetByIdAsync(request.InspectionId);

            if (inspectionToDelete == null)
            {
                throw new NotFoundException(nameof(Inspection), request.InspectionId);
            }

            await _inspectionRepository.DeleteAsync(inspectionToDelete);

            return Unit.Value;
        }
    }
}
