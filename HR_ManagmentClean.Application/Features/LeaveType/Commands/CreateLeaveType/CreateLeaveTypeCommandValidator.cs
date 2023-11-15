using FluentValidation;
using HR_ManagmentClean.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator:
        AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70)
                .WithMessage("{PropertyName} must be fewer than 70");
             
            RuleFor(p => p.DefaultDays)
                .LessThan(100)
                .WithMessage("{PropertyName} must be fewer than 100")
                .GreaterThanOrEqualTo(valueToCompare: 1)
                .WithMessage("{PropertyName} can not be less than 1");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave Type Allready Exists");
            this._leaveTypeRepository = leaveTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);    
        }
    }
}
