using InspectionStatistics.Application.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionStatistics.Persistence.Repositories
{
    public class InspectionRepository : BaseRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(InspectionStatisticsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsInspectionInspectionTypeAndDateUnique(string inspectionType, DateTime inspectionDate)
        {
            var matches =  _dbContext.Inspections.Any(e => e.InspectionType.Equals(inspectionType) && e.Date.Date.Equals(inspectionDate.Date));
            return Task.FromResult(matches);
        }
    }
}
