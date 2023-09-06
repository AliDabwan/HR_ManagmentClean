using AutoMapper;
using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            //convert to domin entity obj

            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);


            //verify
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType),request.Id);
            
            // add to db

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            // return record id

            return Unit.Value;
        }
    }
}
