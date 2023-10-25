using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin;
using HR_ManagmentClean_Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddLocations(List<LeaveAllocation> alocations)
        {
            await _context.AddRangeAsync(alocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
            && q.LeaveTypeId == leaveTypeId
            && q.Period == period);
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations = await _context.LeaveAllocations
                           .Where(q => q.Id == id)
                           .Include(q => q.LeaveType)
                           .FirstOrDefaultAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                           .Where(q => q.EmployeeId == userId)
                           .Include(q => q.LeaveType)
                           .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                                      .Where(q => q.EmployeeId == userId
                                      && q.LeaveTypeId==leaveTypeId)
                                      .FirstOrDefaultAsync();
            return leaveAllocations;
        }
    }
}
