import { PaginatedResult, Pagination } from './../_models/pagination';
import { ChangeTicketStatus } from './../_models/changeTicketStatus';
import { Ticket } from './../_models/ticket';
import { Component, OnInit } from '@angular/core';
import { TicketService } from '../_services/ticket.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css']
})
export class TicketListComponent implements OnInit {
  tickets:Ticket[] = [];
  pagination!: Pagination;
  pageNumber = 1;
  pageSize = 5;

  constructor(private ticket: TicketService, private toastr: ToastrService){}

  ngOnInit(): void {
    this.loadTickets(this.pageNumber, this.pageSize);
  }

  loadTickets(pageNumber: number, pageSize: number){
    this.ticket.getTickets(pageNumber, pageSize)
      .subscribe((res: PaginatedResult<Ticket[]>) => {
        this.tickets = res.result;
        this.pagination = res.pagination;
      }, error => {
        this.toastr.error(error);
    });
  }

  pageChanged(event: any): void{
    this.pagination.currentPage = event.page;
    this.loadTickets(this.pagination.currentPage, this.pagination.itemsPerPage);
  }

  handleTicket(ticket: Ticket){
    var status: ChangeTicketStatus = {id: ticket.id, status: true};
    this.ticket.changeStatus(status).subscribe(res => {
      ticket.status = res;
    }, error => {
      this.toastr.error(error);
    });
  }

  defineColor(ticket: Ticket){
    let ticketDate = new Date(ticket.createdDate).getTime();
    let Time = new Date(Date.now()).getTime() - ticketDate;
    let mintues = Time / (1000 * 60 ); //Diference in minutes

    if(mintues >= 60){
      return 'text-white bg-danger';
    }else if(mintues >= 45){
      return 'text-white bg-primary';
    }else if(mintues >= 30){
      return 'text-white bg-success';
    }else if(mintues >= 15){
      return 'text-white bg-warning';
    }else {
      return '';
    }
  }
}
