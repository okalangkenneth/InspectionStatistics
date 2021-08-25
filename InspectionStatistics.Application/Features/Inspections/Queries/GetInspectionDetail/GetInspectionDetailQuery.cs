
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionDetail;
using MediatR;
using System;

namespace InspectionStatistics.Application.Features.Inspections.GetInspectionDetail
{
    public class GetInspectionDetailQuery: IRequest<InspectionDetailVm>
    {
        public Guid Id { get; set; }
    }
}
