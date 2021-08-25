using InspectionStatistics.Application.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionStatistics.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(InspectionStatisticsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Department>> GetDepartmentsWithInspections(bool includePassedInspections)
        {
            var allDepartments = await _dbContext.Departments.Include(x => x.Inspections).ToListAsync();
            if(!includePassedInspections)
            {
                allDepartments.ForEach(p => p.Inspections.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allDepartments;
        }
    }
}
