import { ChangeTicketStatus } from './../_models/changeTicketStatus';
import { Ticket } from './../_models/ticket';
import { map, Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginatedResult } from '../_models/pagination';


@Injectable({
  providedIn: 'root',
})
export class TicketService {
  baseUrl = 'http://localhost:5057/api/ticket';

  constructor(private http: HttpClient) {}

  getTickets(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Ticket[]>> {
    const paginatedResult: PaginatedResult<Ticket[]> = new PaginatedResult<Ticket[]>();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Ticket[]>(this.baseUrl, {observe: 'response', params}).pipe(
      map((response) => {
        paginatedResult.result = response.body!;
        if (response.headers.get('Pagination') !== null) {
          paginatedResult.pagination = JSON.parse(
            response.headers.get('Pagination')!
          );
        }
        return paginatedResult;
      })
    );
  }

  changeStatus(status: ChangeTicketStatus): Observable<boolean> {
    return this.http.put<boolean>(this.baseUrl, status);
  }
}
