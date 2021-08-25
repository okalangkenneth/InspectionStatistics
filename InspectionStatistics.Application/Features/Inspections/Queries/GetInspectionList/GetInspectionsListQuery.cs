using InspectionStatistics.Application.Features.Inspections;
using MediatR;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Inspectons
{
    public class GetInspectionsListQuery:IRequest<List<InspectionListVm>>
    {

    }
}
