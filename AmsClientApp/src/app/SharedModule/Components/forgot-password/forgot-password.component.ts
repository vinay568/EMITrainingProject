/* eslint-disable eqeqeq */
/* eslint-disable no-param-reassign */
/* eslint-disable no-empty-function */
/* eslint-disable no-unused-vars */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/no-unresolved */
/* eslint-disable import/prefer-default-export */
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { EmployeeManagementService } from 'src/app/Services/EmployeeManagement/employee-management.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
})
export class ForgotPasswordComponent implements OnInit {
  isEmployeeExist : boolean = false;

  resetPasswordForm : FormGroup;

  data:any;

  passwordReset : any;

  constructor(
private form : FormBuilder,
private employeeService : EmployeeManagementService,
    private toastrService : ToastrService,
  ) { }

  ngOnInit(): void {
    this.resetPasswordForm = this.form.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  public checkEmployeeExists(email:any):void {
    this.employeeService.checkUserExistsByEmail(email).subscribe((response :any) => {
      this.data = response;
      this.isEmployeeExist = this.data.result;
    });
  }

  public resetPassword(formdata:any):void {
    if (this.resetPasswordForm.value.password == this.resetPasswordForm.value.confirmPassword) {
      formdata = this.resetPasswordForm.value;
      this.employeeService.resetEmployeePassword(formdata).subscribe((response:any) => {
        this.passwordReset = response;
        this.toastrService.success('Password Changed Successfully \n Redirecting to login page', 'Success', { tapToDismiss: true });
        this.resetPasswordForm.reset();
      });
    } else {
      this.toastrService.warning(' Passwords do not Match \n Try again', 'Warning', { tapToDismiss: true });
    }
  }
}
