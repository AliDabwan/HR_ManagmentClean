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
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, List<LeaveTypeDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDetailDto>> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //query databas 
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            var data =_mapper.Map<List<LeaveTypeDetailDto>>(leaveTypes);
            //convert data obj to dto 
            //return list of dto

            return data;
        }
    }
}
