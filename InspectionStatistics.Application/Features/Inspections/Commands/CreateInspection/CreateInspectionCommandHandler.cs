using AutoMapper;
using InspectionStatistics.Application.Contracts.Infrastructure;
using InspectionStatistics.Application.Contracts.Persistence;
using InspectionStatistics.Application.Features.Inspections.Commands.CreateInspection;
using InspectionStatistics.Application.Models.Mail;
using InspectionStatistics.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Features.Inspections.Commands.CreateEvent
{
    public class CreateInspectionCommandHandler : IRequestHandler<CreateInspectionCommand, Guid>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateInspectionCommandHandler> _logger;


        public CreateInspectionCommandHandler(IMapper mapper, IInspectionRepository inspectionRepository, IEmailService emailService, ILogger<CreateInspectionCommandHandler> logger)
        {
            _mapper = mapper;
            _inspectionRepository = inspectionRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateInspectionCommandValidator(_inspectionRepository);
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @inspection = _mapper.Map<Inspection>(request);

            @inspection = await _inspectionRepository.AddAsync(@inspection);

            //Sending email notification to admin address
            var email = new Email() { To = "okalang.ok@gmail.com", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@inspection.InspectionId} failed due to an error with the mail service: {ex.Message}");
            }

            return @inspection.InspectionId;
        }
    }
}