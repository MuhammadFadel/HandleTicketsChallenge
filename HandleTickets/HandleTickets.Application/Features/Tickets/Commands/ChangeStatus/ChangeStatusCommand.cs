using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Commands.ChangeStatus
{   
    public class ChangeStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
