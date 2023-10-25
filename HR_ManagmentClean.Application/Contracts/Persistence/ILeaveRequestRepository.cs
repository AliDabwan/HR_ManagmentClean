using HR_ManagmentClean.Domin;

namespace HR_ManagmentClean.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(); 
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId); 

    }

}