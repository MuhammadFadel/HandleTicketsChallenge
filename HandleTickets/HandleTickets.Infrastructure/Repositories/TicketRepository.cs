using HandleTickets.Application.Contracts.Persistence;
using HandleTickets.Application.Helpers;
using HandleTickets.Domain.Entities;
using HandleTickets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Infrastructure.Repositories
{   
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(TicketContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<Ticket>> GetTickets(PaginationParams paginationParams)
        {
            var ticketList = _dbContext.Tickets.OrderByDescending(c => c.CreatedDate);                                
            return await PagedList<Ticket>.CreateAsync(ticketList, paginationParams.PageNumber, paginationParams.PageSize) ;
        }
    }
}
