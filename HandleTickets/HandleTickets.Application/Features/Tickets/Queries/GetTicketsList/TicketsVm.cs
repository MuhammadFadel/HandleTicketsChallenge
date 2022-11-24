using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Features.Tickets.Queries.GetTicketsList
{
    public class TicketsVm
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
