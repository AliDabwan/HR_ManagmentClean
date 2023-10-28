using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand:IRequest<Domin.LeaveType>
    {

        public string  Name { get; set; }=string.Empty;
        public int DefaultDays { get; set; }
    }

   
}
