using AutoMapper;
using HandleTickets.Application.Features.Tickets.Commands.CreateTicket;
using HandleTickets.Application.Features.Tickets.Queries.GetTicketsList;
using HandleTickets.Application.Helpers;
using HandleTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleTickets.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            CreateMap<Ticket, TicketsVm>()
                //.ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd/MM/yyyy hh:mm tt")))
                .ReverseMap();
            CreateMap<Ticket, CreateTicketCommand>().ReverseMap();            
        }
    }
}
