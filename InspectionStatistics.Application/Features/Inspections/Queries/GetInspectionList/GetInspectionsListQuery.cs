using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionList;
using MediatR;
using System.Collections.Generic;

namespace InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionsList
{
    public class GetInspectionsListQuery:IRequest<List<InspectionListVm>>
    {

    }
}
