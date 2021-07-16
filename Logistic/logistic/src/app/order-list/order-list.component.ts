import { Component, OnInit } from '@angular/core';
import { LogisticApiService } from '../logistic-api.service';
import { Order, OrderWithEmail } from '../models';

@Component({
  selector: 'logi-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent{

  constructor(private apiSvc: LogisticApiService) { }

  orders: OrderWithEmail[] | undefined;
  selectedDate = new Date(Date.now());

  refresh() {
    
    this.apiSvc.getOrderAsync(new Date(this.selectedDate)).then(
      order => this.orders = order);
  }
  refreshDelivered() {
    
    this.apiSvc.getOrderDeliveredAsync(new Date(this.selectedDate)).then(
      order => this.orders = order);
  }

  delete(id:number | undefined) {
    this.apiSvc.deleteOrderAsync(id?.toString()).then(
      res => {
        this.refresh();
      })
      
    ;
  }
  deliver(order:Order) {
    order.delivered="y";
    this.apiSvc.updateOrderAsync(order).then(
      res => {
        this.refresh();
      })
      
    ;
  }

}
