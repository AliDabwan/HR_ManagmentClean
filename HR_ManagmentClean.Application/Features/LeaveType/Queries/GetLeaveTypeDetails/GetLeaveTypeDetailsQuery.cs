using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    //public class GetLeaveTypesQuery:IRequest<List<LeaveTypeDto>>
    //{
    //}

    public record GetLeaveTypeDetailsQuery(
        int Id
        
        
        )
        : IRequest<LeaveTypeDetailDto>;
   
}
