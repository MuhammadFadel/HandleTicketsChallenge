using AutoMapper;
using HandleTickets.Application.Contracts.Persistence;
using HandleTickets.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Commands.CreateTicket
{ 
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;        
        private readonly ILogger<CreateTicketCommandHandler> _logger;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, ILogger<CreateTicketCommandHandler> logger)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Ticket>(request);
            var newOrder = await _ticketRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            return newOrder.Id;
        }        
    }
}
