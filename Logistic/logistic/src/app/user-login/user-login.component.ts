import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models';

@Component({
  selector: 'logi-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {

  invalidLogin: boolean | undefined;
  constructor(private router: Router, private http: HttpClient) { }

  login(form: NgForm) {
    var user:User ={
      "email":form.value.email,
      "password":form.value.password,
      "name":""
    }
    this.http.post("https://localhost:44376/api/auth/login", user)
    .subscribe(response => {
      const token = (<any>response).token;
      const user = (<any>response).user;
      const admin = (<any>response).admin;
      localStorage.setItem("jwt", token);
      localStorage.setItem("user", user);
      localStorage.setItem("admin", admin);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

}
