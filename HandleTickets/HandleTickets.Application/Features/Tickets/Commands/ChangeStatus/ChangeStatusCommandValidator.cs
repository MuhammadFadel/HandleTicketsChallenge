using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Commands.ChangeStatus
{   
    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull();

            RuleFor(p => p.Status)
               .NotEmpty().WithMessage("{Status} is required.")
               .NotNull();            
        }
    }
}
