using HandleTickets.Application.Helpers;
using HandleTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Contracts.Persistence
{    
    public interface ITicketRepository : IAsyncRepository<Ticket>
    {
        Task<PagedList<Ticket>> GetTickets(PaginationParams paginationParams);
    }
}
