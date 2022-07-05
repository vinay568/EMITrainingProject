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
import { ToastrService } from 'ngx-toastr';
import { LoginServiceService } from 'src/app/Services/Authentication/login-service.service';

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
      this.storeUserInfo();
      this.toastrService.success('Login Successfull', 'Success', { tapToDismiss: true });
      this.route.navigate(['makeRequest']);
    } else {
      this.toastrService.error(' invalid email or password', 'Invalid Credentials', { tapToDismiss: true });
    }
  }

  public storeUserInfo():void {
    sessionStorage.setItem('USERID', this.data.employeeInfo.id);
    sessionStorage.setItem('userName', this.data.employeeInfo.firstName);
    sessionStorage.setItem('managerId', this.data.employeeInfo.managerId);
    sessionStorage.setItem('role', this.data.employeeInfo.roleId);
    sessionStorage.setItem('token', this.data.token);
    sessionStorage.setItem('isLoggedIn', 'true');
  }
}
