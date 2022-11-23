using AutoMapper;
using HandleTickets.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Commands.ChangeStatus
{    
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChangeStatusCommandHandler> _logger;

        public ChangeStatusCommandHandler(ITicketRepository ticketRepository, IMapper mapper, ILogger<ChangeStatusCommandHandler> logger)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id);
            if (ticket == null) return false;

            ticket.Status = request.Status;
            await _ticketRepository.UpdateAsync(ticket);
            _logger.LogInformation($"Ticket {ticket.Id} status is successfully changed.");

            return true;
        }
    }

}
