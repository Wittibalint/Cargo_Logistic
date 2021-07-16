import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';
import { OrderEditComponent } from '../order-edit/order-edit.component';
import { Order} from '../models';
import { OrderListComponent } from '../order-list/order-list.component';

@Component({
  selector: 'logi-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent{

  constructor(private apiSvc: LogisticApiService,
    private router: Router) {
     }

  size: number | undefined;
  weight: number | undefined;
  transportFrom: string | undefined;
  transportFromX: number | undefined;
  transportFromY: number | undefined;
  transportTo: string | undefined;
  transportToX: number | undefined;
  transportToY: number | undefined;
  shippingDate = new Date(Date.now());
  datenow = new Date(Date.now());
  phoneNumber : string|undefined;
  description : string | undefined;
    
    async send() {
      var order:Order = {
        "userId":Number(localStorage.getItem("user")),
        "size":this.size!,
        "weight":this.weight!,
        "transportFrom":this.transportFrom!,
        "transportFromX":this.transportFromX!,
        "transportFromY":this.transportFromY!,
        "transportTo":this.transportTo!,
        "transportToX":this.transportToX!,
        "transportToY":this.transportToY!,
        "shippingDate":this.shippingDate!,
        "registryDate":this.datenow!,
        "phoneNumber":this.phoneNumber!,
        "description":this.description!
        }
    this.apiSvc.createOrderAsync(order).then(() => {
      this.router.navigateByUrl("/customer");
    });

  }

}
