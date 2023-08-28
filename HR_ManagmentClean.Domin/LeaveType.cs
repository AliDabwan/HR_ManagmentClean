using HR_ManagmentClean.Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Domin
{
    public class LeaveType: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }

    }
}
