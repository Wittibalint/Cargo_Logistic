import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import{JwtHelperService} from '@auth0/angular-jwt';

@Injectable()
export class AuthAdminGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelperService, private router: Router) {
  }
  canActivate() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)&&localStorage.getItem("admin")=="y"){
        return true;
    }
    this.router.navigate(["customer"]);
    return false;
  }
}