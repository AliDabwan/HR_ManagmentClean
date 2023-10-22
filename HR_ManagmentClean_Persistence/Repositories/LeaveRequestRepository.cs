using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin;
using HR_ManagmentClean_Persistence.DatabaseContext;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

     
    }
}
