/* eslint-disable max-len */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-alert */
/* eslint-disable no-unused-vars */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { FetchRequestsService } from 'src/app/Services/RequestOperations/FetchOperations/fetch-requests.service';
import { RequestStatusService } from 'src/app/Services/RequestOperations/RequestStatusOperations/request-status.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css'],
})
export class NavigationBarComponent implements OnInit {
  userName :string = '';

  roleId:any;

  requestsDataByStatus : any;

  constructor(private route : Router, private requestsService : RequestService, private requestFetchService: FetchRequestsService) { }

  ngOnInit(): void {
    this.userName = sessionStorage.getItem('userName');
    this.roleId = sessionStorage.getItem('role');
  }

  public logout() {
    this.route.navigate(['login']);
  }

  public getRequestsByStatus(id:any):void {
    this.requestFetchService.getRequestsByStatusId(id).subscribe((response:any) => {
      this.requestsDataByStatus = response;
      this.route.navigate(['viewRequest']);
    });
  }
}
