import { TicketToCreate } from './../_models/ticketToCreate';
import { ToastrService } from 'ngx-toastr';
import { TicketService } from './../_services/ticket.service';

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { City, district, Governorate } from '../_models/address';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  createForm!: FormGroup;
  ticketToCreate!: TicketToCreate;

  districts: district[] = [{name: "Dis 1"}, {name: "Dis 2"}, {name: "Dis 3"}, {name: "Dis 4"},
                          {name: "Dis 5"}, {name: "Dis 6"}, {name: "Dis 7"}, {name: "Dis 8"},
                          {name: "Dis 9"}, {name: "Dis 10"}, {name: "Dis 11"}, {name: "Dis 12"},
                          {name: "Dis 13"}, {name: "Dis 14"}, {name: "Dis 15"}, {name: "Dis 16"},]
  selectionDistricts: any;

  cities: City[] = [{name:"City 1", districts: [this.districts[0], this.districts[1]] },
                     {name:"City 2", districts: [this.districts[2], this.districts[3]]},
                     {name:"City 3", districts: [this.districts[4], this.districts[5]]},
                     {name:"City 4", districts: [this.districts[6], this.districts[7]]},];
  selectionCities: any;

  governorates: Governorate[] = [{ name: 'Cairo', cities: [this.cities[0], this.cities[1]]},
                                  { name: 'Giza', cities: [this.cities[2], this.cities[3]]}];


  constructor(private ticket: TicketService, private toaster: ToastrService, private fb: FormBuilder){}

  ngOnInit(): void {
    this.createTicketForm();
  }

  createTicketForm(){
    this.createForm = this.fb.group({
      phoneNumber: ['', Validators.required],
      governorate: ['', Validators.required],
      city: ['', Validators.required],
      district: ['', Validators.required]
    });
  }

  submitTicket(){
    if(this.createForm.valid){
      this.ticketToCreate = Object.assign({}, this.createForm.value);
      this.ticket.createTicket(this.ticketToCreate).subscribe(res => {
        if(res !== 0){
          this.toaster.success('Created Successfully With Id ' + res);
          this.createForm.reset();
        }
      }, error => {
        this.toaster.error(error);
      });
    }
  }

  filterCities(governorate: any){
    this.selectionCities = this.governorates.find(c => c.name === governorate.value)?.cities;
  }

  filterDistricts(city: any){
    this.selectionDistricts = this.cities.find(c => c.name === city.value)?.districts;
  }
}
