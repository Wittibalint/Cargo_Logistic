import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { DepotEditComponent } from '../depot-edit/depot-edit.component';
import { LogisticApiService } from '../logistic-api.service';
import { Depot } from '../models';

@Component({
  selector: 'logi-new-depot',
  templateUrl: './new-depot.component.html',
  styleUrls: ['./new-depot.component.scss']
})
export class NewDepotComponent implements OnInit {


    constructor(private apiSvc: LogisticApiService,
      private router: Router) { }
  
    ngOnInit(): void {
    }
  
    address: string | undefined;
    locationX: number | undefined;
    locationY: number | undefined;
  
    async send() {
       var json:Depot = {
      "address":this.address!,
      "locationX":this.locationX!,
      "locationY":this.locationY!

      }
      this.apiSvc.createDepotsAsync(json).then(() => {
        this.router.navigateByUrl("/admin/depot");
      });
  
    }
}
