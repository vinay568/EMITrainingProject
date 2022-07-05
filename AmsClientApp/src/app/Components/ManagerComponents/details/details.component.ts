/* eslint-disable import/no-unresolved */
/* eslint-disable max-len */
/* eslint-disable no-unused-vars */
/* eslint-disable no-empty-function */
/* eslint-disable class-methods-use-this */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { formatDate } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  MatDialog, MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RequestsModel } from 'src/app/Models/requests.model';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { RequestStatusService } from 'src/app/Services/RequestOperations/RequestStatusOperations/request-status.service';
import { RejectedReasonComponent } from '../../rejected-reason/rejected-reason.component';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  requestId : any;

  requestDetailsForm : FormGroup;

  requestDetails : any;

  roleId : any;

  constructor(
private dialog : MatDialogRef<DetailsComponent>,
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

  private setValue(data:RequestsModel) {
    this.requestDetailsForm.setValue({

      purpose: data.purpose,
      estimatedCost: data.estimatedCost,
      advanceAmount: data.advanceAmount,
      description: data.description,
      planDate: data.planDate,
    });
  }

  public approveRequest(id:any):void {
    this.requestStatusService.setApprovedStatus(id, this.requestDetails).subscribe((response:any) => {
      this.requestDetails = response;
      this.toastrService.success('Request Approved', 'Success', { tapToDismiss: true });
      this.dialog.close();
    });
  }

  public rejectRequest(id:any):void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '45%';
    dialogConfig.height = '60%';
    const dialogOpen = this.dialogService.open(RejectedReasonComponent, dialogConfig);
    dialogOpen.componentInstance.requestId = id;
    this.dialog.close();
  }

  public viewRejectedReason(id:any):void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '45%';
    dialogConfig.height = '60%';
    const dialogOpen = this.dialogService.open(RejectedReasonComponent, dialogConfig);
    dialogOpen.componentInstance.requestId = id;
    this.dialog.close();
  }

  public forwardRequest(id:any):void {
    this.requestStatusService.setForwardedStatus(id, this.requestDetails).subscribe((response:any) => {
      this.requestDetails = response;
      this.toastrService.success('Request Forwarded', 'Success', { tapToDismiss: true });
    });
  }
}
