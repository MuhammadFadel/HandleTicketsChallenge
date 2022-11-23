using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Commands.CreateTicket
{  
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PhoneNumber} is required.")
                .NotNull();

            RuleFor(p => p.Governorate)
               .NotEmpty().WithMessage("{Governorate} is required.")
               .NotNull();

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{City} is required.")
                .NotNull();

            RuleFor(p => p.District)
                .NotEmpty().WithMessage("{District} is required.")
                .NotNull();
        }
    }
}
