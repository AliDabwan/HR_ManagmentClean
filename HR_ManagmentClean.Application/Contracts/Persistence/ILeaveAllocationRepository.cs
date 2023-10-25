using HR_ManagmentClean.Domin;

namespace HR_ManagmentClean.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
        Task<bool> AllocationExists(string userId,int leaveTypeId,int period);
        Task AddLocations(List<LeaveAllocation> alocations);
        Task<LeaveAllocation> GetUserAllocations(string userId,int leaveTypeId);

    }

}