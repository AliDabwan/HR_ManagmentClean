﻿using AutoMapper;
using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Application.Exceptions;
using HR_ManagmentClean.Domin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //query databas 
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if(leaveTypes==null) {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            //verify
            var data =_mapper.Map<LeaveTypeDetailDto>(leaveTypes);
            //convert data obj to dto 
            //return list of dto

            return data;
        }
    }
}
