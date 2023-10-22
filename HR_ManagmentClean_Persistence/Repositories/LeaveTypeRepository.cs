using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin;
using HR_ManagmentClean_Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
           return await _context.LeaveTypes.AnyAsync(e => e.Name == name);
        }
    }
}
