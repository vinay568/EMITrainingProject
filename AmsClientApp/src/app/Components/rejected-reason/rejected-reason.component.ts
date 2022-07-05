/* eslint-disable max-len */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
/* eslint-disable class-methods-use-this */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { formatDate } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RequestsModel } from 'src/app/Models/requests.model';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { RequestStatusService } from 'src/app/Services/RequestOperations/RequestStatusOperations/request-status.service';

@Component({
  selector: 'app-rejected-reason',
  templateUrl: './rejected-reason.component.html',
  styleUrls: ['./rejected-reason.component.css'],
})
export class RejectedReasonComponent implements OnInit {
  requestId :any;

  requestDetails:any;

  requestDetailsForm:any;

  isRejected = false;

  roleId : any;

  constructor(
private dialog : MatDialogRef<RejectedReasonComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
     private route : Router,
      private form : FormBuilder,
     private requestService : RequestService,
     private requestStatusService : RequestStatusService,
     private toastrService : ToastrService,
     private dialogService : MatDialog,
  ) { }

  ngOnInit(): void {
    this.getRequestDetails();
    this.roleId = sessionStorage.getItem('role');
    this.requestDetailsForm = this.form.group({
      purpose: [''],
      estimatedCost: [''],
      advanceAmount: [''],
      planDate: [''],
      description: [''],
      rejectedReason: ['', Validators.required],
    });
  }

  public getRequestDetails():void {
    this.requestService.getRequestById(this.requestId).subscribe((response:any) => {
      this.requestDetails = response;
      const date = new Date(response.planDate);
      const format = 'yyyy-MM-dd';
      const locale = 'en-US';
      response.planDate = formatDate(date, format, locale);
      this.setValue(response);
    });
  }

  private setValue(data:RequestsModel):void {
    this.requestDetailsForm.setValue({

      purpose: data.purpose,
      estimatedCost: data.estimatedCost,
      advanceAmount: data.advanceAmount,
      description: data.description,
      planDate: data.planDate,
      rejectedReason: data.rejectedReason,
    });
  }

  public onSubmit(id:any):void {
    this.requestStatusService.setRejectedStatus(id, this.requestDetailsForm.value).subscribe((response:any) => {
      this.requestDetails = response;
      this.isRejected = !this.isRejected;
      this.toastrService.success('Reason for rejection submitted successfully', 'Request Rejected', { tapToDismiss: true });
      this.dialog.close();
    });
  }
}
