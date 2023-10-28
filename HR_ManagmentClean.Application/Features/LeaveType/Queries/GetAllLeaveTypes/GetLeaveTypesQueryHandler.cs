using AutoMapper;
using HR_ManagmentClean.Application.Contracts.Logging;
using HR_ManagmentClean.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypeQueryHandler> _appLogger;

        public GetLeaveTypeQueryHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<GetLeaveTypeQueryHandler> appLogger)
        {
            
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._appLogger = appLogger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //query databas 
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            var data =_mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            //convert data obj to dto 
            //return list of dto
            _appLogger.LogInformation("Leave types were retrivable successfully");
            return data;
        }
    }
}
