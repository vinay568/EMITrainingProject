/* eslint-disable eqeqeq */
/* eslint-disable import/no-unresolved */
/* eslint-disable import/prefer-default-export */
/* eslint-disable no-useless-constructor */
/* eslint-disable no-unused-vars */
/* eslint-disable no-empty-function */
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { EmployeeManagementService } from 'src/app/Services/EmployeeManagement/employee-management.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ErrorDialogComponent } from 'src/app/SharedModule/Components/error-dialog/error-dialog.component';
import { FetchRequestsService } from 'src/app/Services/RequestOperations/FetchOperations/fetch-requests.service';
import { DetailsComponent } from '../details/details.component';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css'],
})
export class ManagerComponent implements OnInit {
  public cancelClicked:boolean = true;

  public isDataLoaded: boolean = false;

  public requests:any;

  page:any;

  term:any;

  requester:any;

  roleId : any;

  constructor(
private requestsService : RequestService,
private requestFetchService : FetchRequestsService,
private toastrService : ToastrService,
private employeeService : EmployeeManagementService,
private dialog : MatDialog,
  ) { }

  ngOnInit(): void {
    this.getEmployeeRequests(sessionStorage.getItem('USERID'));
    this.roleId = sessionStorage.getItem('role');
  }

  public getEmployeeRequests(id:any) {
    this.requestFetchService.getApproverRequests(id).subscribe((response:any) => {
      this.isDataLoaded = true;
      this.requests = response;
      this.checkIfEmpty();
    });
  }

  public checkIfEmpty() {
    if (this.requests.length == 0) {
      this.dialog.open(ErrorDialogComponent);
    }
  }

  public details(id:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '38%';
    dialogConfig.height = '58%';
    const dialogOpen = this.dialog.open(DetailsComponent, dialogConfig);
    dialogOpen.componentInstance.requestId = id;
  }
}
