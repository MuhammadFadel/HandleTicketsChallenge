using HandleTickets.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Queries.GetTicketsList
{    
    public class GetTicketsListQuery : IRequest<PagedList<TicketsVm>>
    {
        public PaginationParams PaginationParams { get; set; }

        public GetTicketsListQuery(PaginationParams paginationParams)
        {
            PaginationParams = paginationParams ?? throw new ArgumentNullException(nameof(paginationParams));
        }
    }
}
