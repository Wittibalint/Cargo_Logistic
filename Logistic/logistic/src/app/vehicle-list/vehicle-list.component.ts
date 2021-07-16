import { Component, OnInit } from '@angular/core';

import { LogisticApiService } from '../logistic-api.service';
import { Vehicle } from '../models';

@Component({
  selector: 'logi-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss']
})
export class VehicleListComponent {

  constructor(private apiSvc: LogisticApiService) { }

  vehicles: Vehicle[] | undefined;

  refresh() {
    this.apiSvc.getVehiclesAsync().then(
      vehicles => this.vehicles = vehicles);
  }
  delete(id:number | undefined) {
    this.apiSvc.deleteVehicleAsync(id?.toString()).then(
      res => {
        this.refresh();
      })
      
    ;
  }
  

}
