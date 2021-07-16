import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';
import { Depot, Vehicle } from '../models';

@Component({
  selector: 'logi-new-vehicle',
  templateUrl: './new-vehicle.component.html',
  styleUrls: ['./new-vehicle.component.scss']
})
export class NewVehicleComponent implements OnInit{

  constructor(private apiSvc: LogisticApiService,
    private router: Router) { }
  
  depots: any;
  selectedDepot:any;
  
  speed: number | undefined;
  maxSize: number | undefined;
  maxWeight: number | undefined;
  depotId: number | undefined;
  license: string | undefined;

  ngOnInit(): void {
    this.apiSvc.getDepotsAsync().then(
      depot => this.depots=depot
    ).then(any=>{ this.selectedDepot = this.depots[0] })
  }
  async send() {
    var vehicle:Vehicle = {
      "speed":this.speed!,
      "maxSize":this.maxSize!,
      "maxWeight":this.maxWeight!,
      "depotId":Number(this.selectedDepot.id!),
      "licensePlate":this.license!
      }
    this.apiSvc.createVehicleAsync(vehicle).then(() => {
      this.router.navigateByUrl("/admin/vehicle");
    });

  }

}
