import { Component, OnInit } from '@angular/core';
import { LogisticApiService } from '../logistic-api.service';
import { Order } from '../models';
import{JwtHelperService} from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'logi-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.scss']
})
export class UserHomeComponent{

  constructor(private apiSvc: LogisticApiService, private jwtHelper: JwtHelperService, private router: Router) { }

  orders: Order[] | undefined;
  user = localStorage.getItem("user");

  refresh() {
    
    this.apiSvc.getOrdersByUserIdAsync(this.user?.toString()).then(
      order => this.orders = order);
  }
  isUserAuthenticated() {
    const token: string|null = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  public logOut = () => {
    this.router.navigate(["/"]);
    localStorage.removeItem("jwt");
    localStorage.removeItem("user");
    localStorage.removeItem("admin");
    
  }

}
