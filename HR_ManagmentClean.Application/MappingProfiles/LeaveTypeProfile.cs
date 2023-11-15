using AutoMapper;
using HR_ManagmentClean.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR_ManagmentClean.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR_ManagmentClean.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR_ManagmentClean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR_ManagmentClean.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.MappingProfiles
{
    public class LeaveTypeProfile:Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();

        }
    }
}
