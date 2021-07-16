import { Component, OnInit } from '@angular/core';
import { LogisticApiService } from '../logistic-api.service';
import { Depot } from '../models';

@Component({
  selector: 'logi-depot-list',
  templateUrl: './depot-list.component.html',
  styleUrls: ['./depot-list.component.scss']
})
export class DepotListComponent {

  constructor(private apiSvc: LogisticApiService) { }

  depots: Depot[] | undefined;

  refresh() {
    this.apiSvc.getDepotsAsync().then(
      depots => this.depots = depots);
  }
  delete(id:number | undefined) {
    this.apiSvc.deleteDepotAsync(id?.toString()).then(
      res => {
        this.refresh();
      })
      
    ;
  }

}
