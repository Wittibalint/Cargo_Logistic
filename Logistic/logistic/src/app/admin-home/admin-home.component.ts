import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import{JwtHelperService} from '@auth0/angular-jwt';
@Component({
  selector: 'logi-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})
export class AdminHomeComponent implements OnInit {

  constructor(private jwtHelper: JwtHelperService, private router: Router) { }

  ngOnInit(): void {
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
