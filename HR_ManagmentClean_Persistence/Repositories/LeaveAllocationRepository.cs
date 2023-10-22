using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin;
using HR_ManagmentClean_Persistence.DatabaseContext;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }


    }
}
