using MediatR;
using System;

namespace InspectionStatistics.Application.Features.Inspections.Commands.DeleteEvent
{
    public class DeleteInspectionCommand: IRequest
    {
        public Guid InspectionId { get; set; }
    }
}
