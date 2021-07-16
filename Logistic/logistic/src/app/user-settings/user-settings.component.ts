import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';

@Component({
  selector: 'logi-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent implements OnInit, OnDestroy {
  id: number|undefined;
  private sub: any;
  user:any;
  password2:string|undefined;
  dialog: string|undefined;

  constructor(
    private apiSvc: LogisticApiService,
    private route: ActivatedRoute,
    private router: Router) { }

    ngOnInit() {
      this.sub = this.route.params.subscribe(params => {
         this.id = +params['id']; // (+) converts string 'id' to a number
         this.apiSvc.getUserByAsync(this.id.toString()
         ).then(
           user => this.user=user
         )
         // In a real app: dispatch action to load the details here.
      });
    }
    ngOnDestroy() {
      this.sub.unsubscribe();
    }
    async send() {
      if(this.password2 == this.user.password){
        this.apiSvc.updateUserAsync(this.user).then(() => {
          this.router.navigateByUrl("/customer");
        });
      }
      else{
        alert("Passwords need match")
      }
    }

}
