import { TicketComponent } from './ticket/ticket.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketListComponent } from './ticket-list/ticket-list.component';

export const routes: Routes = [
  {path: 'tickets', component: TicketListComponent},
  {path: 'create', component: TicketComponent},
  {path: '**', component: TicketListComponent, pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
