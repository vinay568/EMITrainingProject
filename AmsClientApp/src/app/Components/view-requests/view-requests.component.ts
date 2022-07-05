/* eslint-disable no-console */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-useless-constructor */
/* eslint-disable no-unused-vars */
/* eslint-disable eqeqeq */
/* eslint-disable import/prefer-default-export */
/* eslint-disable no-empty-function */
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { throwToolbarMixedModesError } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { FetchRequestsService } from 'src/app/Services/RequestOperations/FetchOperations/fetch-requests.service';
import { RequestStatusService } from 'src/app/Services/RequestOperations/RequestStatusOperations/request-status.service';
import { ErrorDialogComponent } from '../../SharedModule/Components/error-dialog/error-dialog.component';
import { RejectedReasonComponent } from '../rejected-reason/rejected-reason.component';

@Component({
  selector: 'app-view-requests',
  templateUrl: './view-requests.component.html',
  styleUrls: ['./view-requests.component.css'],
})
export class ViewRequestsComponent implements OnInit {
  requests:any;

  Requests :any;

  requestsData:any;

  data:any[];

  errorMessage:any;

  isDataLoaded = false;

  term:any;

  p:any;

  rtoken : any;

  public cancelClicked:boolean = false;

  constructor(
private requestsService : RequestService,
private requestFetchService : FetchRequestsService,
private dialog : MatDialog,
private toastrService : ToastrService,
private route : Router,
  ) { }

  ngOnInit(): void {
    sessionStorage.setItem('viewAllRequests', '1');
    this.requestsService.refreshRequired.subscribe();
    this.getEmployeeRequests(sessionStorage.getItem('USERID'));
    this.rtoken = sessionStorage.getItem('token');
  }

  public getEmployeeRequests(id:any):void {
    this.requestFetchService.getEmployeeRequests(id).subscribe((response:any) => {
      this.requests = response;
      this.checkIfEmpty();
      this.isDataLoaded = true;
    }, (error) => { console.log(error); });
  }

  public checkIfEmpty():void {
    if (this.requests.length == 0) {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      this.dialog.open(ErrorDialogComponent, dialogConfig);
    }
  }

  public getRequestsByStatus(statusId:any):void {
    this.requestFetchService.getRequestsByStatusId(statusId).subscribe((response:any) => {
      this.requests = response;
    });
  }

  public editRequest(id:any):void {
    this.route.navigate(['/editRequest', id]);
  }

  public withDraw(id:any):void {
    this.requestsService.withDrawRequest(id).subscribe((response:any) => {
      this.toastrService.success('Request withdrawn successfully');
      this.getEmployeeRequests(sessionStorage.getItem('USERID'));
    }, (error) => { console.log(error); });
  }

  public viewRejectedReason(id:any):void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '35%';
    dialogConfig.height = '62%';
    const dialogOpen = this.dialog.open(RejectedReasonComponent, dialogConfig);
    dialogOpen.componentInstance.requestId = id;
  }

  public uploadRequestBill(id:any):void {
    this.route.navigate(['uploadBill', id], { queryParams: { reqid: id, eid: this.rtoken } });
  }
}
