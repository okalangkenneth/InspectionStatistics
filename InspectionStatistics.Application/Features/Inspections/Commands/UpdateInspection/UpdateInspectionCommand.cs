using MediatR;
using System;

namespace InspectionStatistics.Application.Features.Inspections.Commands.UpdateInspection
{
    public class UpdateInspectionCommand: IRequest
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public int Price { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
