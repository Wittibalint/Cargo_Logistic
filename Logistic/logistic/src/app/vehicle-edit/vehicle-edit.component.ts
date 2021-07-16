import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';
import { Depot, Vehicle } from '../models';
import { VehicleListComponent } from '../vehicle-list/vehicle-list.component';

@Component({
  selector: 'logi-vehicle-edit',
  templateUrl: './vehicle-edit.component.html',
  styleUrls: ['./vehicle-edit.component.scss']
})
export class VehicleEditComponent implements OnInit, OnDestroy {
  id: number|undefined;
  private sub: any;
  vehicle:any;
  depots: any;
  selectedDepot:any;

  constructor(
    private apiSvc: LogisticApiService,
    private route: ActivatedRoute,
    private router: Router) { }

    ngOnInit() {
      this.apiSvc.getDepotsAsync().then(
        depot => this.depots=depot
      ).then(
        res => {
          this.sub = this.route.params.subscribe(params => {
            this.id = +params['id']; // (+) converts string 'id' to a number
            this.apiSvc.getVehicleByIdAsync(this.id.toString()
            ).then(
              vehicle => this.vehicle=vehicle
            ).then(res => {
             for(var depo of this.depots){
               if(depo.id == this.vehicle.depotId){
                 this.selectedDepot = depo;
               }
            }  
           })
            // In a real app: dispatch action to load the details here.
         });
        }
      ) 
    }
    ngOnDestroy() {
      this.sub.unsubscribe();
    }
    async send() {
      this.vehicle.depotId = Number(this.selectedDepot.id)
      this.apiSvc.updateVehicleAsync(this.vehicle).then(() => {
        this.router.navigateByUrl("/admin/vehicle");
      });
    }

}
