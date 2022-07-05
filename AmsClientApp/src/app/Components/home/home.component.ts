/* eslint-disable import/prefer-default-export */
/* eslint-disable no-useless-constructor */
/* eslint-disable no-empty-function */
/* eslint-disable no-param-reassign */
/* eslint-disable no-console */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { EmployeeManagementService } from 'src/app/Services/EmployeeManagement/employee-management.service';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  requestData:any;

  requestForm : FormGroup;

  approver :any;

  managerId:any;

  approverData:any;

  reqId:any;

  constructor(
private form:FormBuilder,
private requestService:RequestService,
private toastrService : ToastrService,
private employeeService : EmployeeManagementService,
  ) { }

  ngOnInit(): void {
    this.requestForm = this.form.group({
      purpose: ['', Validators.required],
      approver: ['', Validators.required],
      estimatedCost: ['', Validators.required],
      advanceAmount: ['', Validators.required],
      description: ['', Validators.required],
      planDate: ['', Validators.required],
    });
    this.managerId = sessionStorage.getItem('managerId');
    this.getManagerDetails(this.managerId);
  }

  public onSubmit(formData:any) {
    this.reqId = formData.approver;
    if (this.requestForm.valid && (formData.advanceAmount < formData.estimatedCost)) {
      this.requestService.addRequest(formData).subscribe((response:any) => {
        this.requestData = response;
      }, (error) => { console.log(error); });

      window.location.reload();
      this.formMsg();
    } else {
      this.toastrService.error('Please fill all details & Advance should be less than Estimated!!!', 'Validation Error', { tapToDismiss: true });
    }
  }

  public formMsg() {
    this.toastrService.success('Hey Congrats !! Your request has been submitted', 'Success');
  }

  public getManagerDetails(id:any):void {
    this.employeeService.getEmployeeById(id).subscribe((response:any) => {
      this.approverData = response;
      this.approver = `${this.approverData.firstName} ${this.approverData.lastName}`;
      console.log(this.approver);
    }, (error) => { console.log(error); });
  }
}
