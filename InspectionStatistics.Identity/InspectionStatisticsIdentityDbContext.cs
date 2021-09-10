using InspectionStatistics.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InspectionStatistics.Identity
{
    public class InspectionStatisticsIdentityDbContext : IdentityDbContext <ApplicationUser>
    {
            
            public InspectionStatisticsIdentityDbContext(DbContextOptions<InspectionStatisticsIdentityDbContext> options) : base(options)
            {

            }
       
    }
}
