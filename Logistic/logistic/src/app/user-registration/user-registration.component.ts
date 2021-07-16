import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogisticApiService } from '../logistic-api.service';
import { User } from '../models';

@Component({
  selector: 'logi-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent{

  constructor(private apiSvc: LogisticApiService,
    private router: Router) { }

  email:string|undefined;
  password:string|undefined;
  password2:string|undefined;
  name:string|undefined;

  async send() {
    let user:User = {
      "email":this.email!,
      "name":this.name!,
      "password":this.password!
    }

    if(this.password2 == user.password){
      this.apiSvc.createUserAsync(user).then(() => {
        this.router.navigateByUrl("/login");
      });
    }
    else{
      alert("Passwords need match")
    }
  }

}
