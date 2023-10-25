using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin;
using HR_ManagmentClean_Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests= await _context.LeaveRequests
                .Include(q=>q.LeaveType)
                .ToListAsync();
            return leaveRequests;

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                          .Where(x => x.RequestingEmployeeId == userId)
                          .Include(q => q.LeaveType)
                          .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequests = await _context.LeaveRequests
                          .Where(x => x.Id == id)
                          .Include(q => q.LeaveType)
                          .FirstOrDefaultAsync();
            return leaveRequests;

        }
    }
}
