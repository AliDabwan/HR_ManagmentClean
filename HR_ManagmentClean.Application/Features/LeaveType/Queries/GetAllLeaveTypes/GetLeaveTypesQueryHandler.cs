using AutoMapper;
using HR_ManagmentClean.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetAllLeaveTypesQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //query databas 
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            var data =_mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            //convert data obj to dto 
            //return list of dto

            return data;
        }
    }
}
