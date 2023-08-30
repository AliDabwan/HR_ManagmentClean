using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
