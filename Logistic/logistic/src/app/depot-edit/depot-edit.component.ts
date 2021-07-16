import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';

@Component({
  selector: 'logi-depot-edit',
  templateUrl: './depot-edit.component.html',
  styleUrls: ['./depot-edit.component.scss']
})
export class DepotEditComponent implements OnInit, OnDestroy {
  id: number|undefined;
  private sub: any;
  depot:any;

  constructor(
    private apiSvc: LogisticApiService,
    private route: ActivatedRoute,
    private router: Router) { }

    ngOnInit() {
      this.sub = this.route.params.subscribe(params => {
         this.id = +params['id']; // (+) converts string 'id' to a number
         this.apiSvc.getDepotByIdAsync(this.id.toString()
         ).then(
           depot => this.depot=depot
         )
         // In a real app: dispatch action to load the details here.
      });
    }
    ngOnDestroy() {
      this.sub.unsubscribe();
    }
    async send() {
      this.apiSvc.updateDepotsAsync(this.depot).then(() => {
        this.router.navigateByUrl("/admin/depot");
      });
    }
}
