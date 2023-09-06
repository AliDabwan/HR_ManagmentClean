using AutoMapper;
using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Domin.LeaveType>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Domin.LeaveType> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validat incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validateResult=await validator.ValidateAsync(request);
            if (!validateResult.IsValid)
                //thrw excep
                throw new BadRequestException("Invalid LeaveType", validateResult);
            //convert to domin entity obj

            var leaveTypeToCreate = _mapper.Map<Domin.LeaveType>(request);

            // add to db

            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            // return record id

            return leaveTypeToCreate;
        }
    }
}
