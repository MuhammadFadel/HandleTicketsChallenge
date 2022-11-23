using AutoMapper;
using HandleTickets.Application.Contracts.Persistence;
using HandleTickets.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Queries.GetTicketsList
{    
    public class GetTicketsListQueryHandler : IRequestHandler<GetTicketsListQuery, PagedList<TicketsVm>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetTicketsListQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PagedList<TicketsVm>> Handle(GetTicketsListQuery request, CancellationToken cancellationToken)
        {
            var ticketPagedList = await _ticketRepository.GetTickets(request.PaginationParams);
            var ticketVm = _mapper.Map<IEnumerable<TicketsVm>>(ticketPagedList);            

            // for mapping the list and keep the pagination data
            return new PagedList<TicketsVm>(ticketVm, ticketPagedList.TotalCount, ticketPagedList.CurrentPage, ticketPagedList.PageSize);
        }
    }
}
