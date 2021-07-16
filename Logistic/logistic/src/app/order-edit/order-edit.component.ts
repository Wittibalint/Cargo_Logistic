import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';

@Component({
  selector: 'logi-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.scss']
})
export class OrderEditComponent implements OnInit, OnDestroy {
  id: number|undefined;
  private sub: any;
  order:any;

  constructor(
    private apiSvc: LogisticApiService,
    private route: ActivatedRoute,
    private router: Router) { }

    ngOnInit() {
      this.sub = this.route.params.subscribe(params => {
         this.id = +params['id']; // (+) converts string 'id' to a number
         this.apiSvc.getOrderByIdAsync(this.id.toString()
         ).then(
           order => this.order=order
         )
         // In a real app: dispatch action to load the details here.
      });
    }
    ngOnDestroy() {
      this.sub.unsubscribe();
    }
    async send() {
      this.apiSvc.updateOrderAsync(this.order).then(() => {
        this.router.navigateByUrl("/admin/order");
      });
    }
}
