using HandleTickets.API.Extensions.Pagination;
using HandleTickets.Application.Features.Tickets.Commands.CreateTicket;
using HandleTickets.Application.Features.Tickets.Queries.GetTicketsList;
using HandleTickets.Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HandleTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("/tickets", Name = "GetTickets")]
        [ProducesResponseType(typeof(IEnumerable<TicketsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TicketsVm>>> GetTickets([FromQuery]PaginationParams paginationParams)
        {
            var query = new GetTicketsListQuery(paginationParams);
            var tickets = await _mediator.Send(query);
            Response.AddPaginationHeader(tickets.CurrentPage, tickets.PageSize, tickets.TotalCount, tickets.TotalPages);
            return Ok(tickets);
        }

        // testing purpose
        [HttpPost(Name = "CreateTicket")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTicket(CreateTicketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
