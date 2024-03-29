﻿using HR_ManagmentClean.Domin;

namespace HR_ManagmentClean.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);

    }

}