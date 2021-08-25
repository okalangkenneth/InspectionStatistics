using MediatR;
using System;

namespace InspectionStatistics.Application.Features.Inspections.Commands.CreateInspection
{
    public class CreateInspectionCommand: IRequest<Guid>
    {
        public string InspectionType { get; set; }
        public int Price { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid DepartmnetId { get; set; }
        public override string ToString()
        {
            return $"Inspection type: {InspectionType}; Price: {Price}; By: {Client}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
