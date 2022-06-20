/* eslint-disable no-console */
/* eslint-disable no-empty-function */
/* eslint-disable eqeqeq */
/* eslint-disable no-underscore-dangle */
/* eslint-disable no-unused-vars */
/* eslint-disable no-useless-constructor */
/* eslint-disable max-len */
/* eslint-disable import/prefer-default-export */
/* eslint-disable import/no-unresolved */
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder, FormGroup, NgForm, Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrComponentlessModule, ToastrService } from 'ngx-toastr';
import { LoginServiceService } from 'src/app/Services/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;

  data:any;

  user:any;

  userId:any;

  userName: string = '';

  constructor(
private route : Router,
private form : FormBuilder,
private _loginService :LoginServiceService,
private toastrService : ToastrService,
  ) { }

  ngOnInit(): void {
    sessionStorage.clear();
    this.loginForm = this.form.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  public onSubmit(form:NgForm) {
    return this._loginService.loginUser(form).subscribe(
      (response) => {
        console.log(response);
        this.data = response;
        this.userChecked();
      },
      (error) => { console.log(error); },
    );
  }

  public userChecked():void {
    if (this.data) {
      if (this.data.roleId == 4) {
        this.storeUserInfo();
        this.toastrService.success('Login Successfull', 'Success', { tapToDismiss: true });
        this.route.navigate(['makeRequest']);
      } else if (this.data.roleId == 3 || this.data.roleId == 2 || this.data.roleId == 1) {
        this.storeUserInfo();
        this.route.navigate(['employeeRequests']);
      }
    } else {
      sessionStorage.setItem('LoggedIn', '2');
      this.toastrService.error(' invalid email or password', 'Invalid Credentials', { tapToDismiss: true });
    }
  }

  public storeUserInfo():void {
    sessionStorage.setItem('USERID', this.data.id);
    sessionStorage.setItem('userName', this.data.firstName);
    sessionStorage.setItem('managerId', this.data.managerId);
    sessionStorage.setItem('role', this.data.roleId);
  }
}
