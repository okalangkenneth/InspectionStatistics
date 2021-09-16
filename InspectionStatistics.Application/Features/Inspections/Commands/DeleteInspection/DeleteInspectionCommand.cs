using MediatR;
using System;

namespace InspectionStatistics.Application.Features.Inspections.Commands.DeleteInspection
{
    public class DeleteInspectionCommand: IRequest
    {
        public Guid InspectionId { get; set; }
    }
}
