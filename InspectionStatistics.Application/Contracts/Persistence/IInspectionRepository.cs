using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Contracts.Persistence
{
    public interface IInspectionRepository: IAsyncRepository<Inspection>
    {
        Task<bool> IsInspectionInspectionTypeAndDateUnique(string InspectionType, DateTime inspectionDate);
        
    }
}
