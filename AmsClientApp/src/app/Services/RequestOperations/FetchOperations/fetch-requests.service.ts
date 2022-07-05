/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RequestsModel } from '../../../Models/requests.model';

@Injectable({
  providedIn: 'root',
})
export class FetchRequestsService {
  fetchUserRequestsUrl = environment.userRequests;

  constructor(private http : HttpClient) { }

  public getApproverRequests(managerId:any):Observable<RequestsModel> {
    return this.http.get<RequestsModel>(`${this.fetchUserRequestsUrl}/GetManagerRequests?id=${managerId}`);
  }

  public getEmployeeRequests(employeeId:any):Observable<RequestsModel> {
    return this.http.get<RequestsModel>(`${this.fetchUserRequestsUrl}/GetEmployeeRequests?id=${employeeId}`);
  }

  public getRequestsByStatusId(statusId:any):Observable<RequestsModel> {
    return this.http.get<RequestsModel>(`${this.fetchUserRequestsUrl}/GetRequestsByStatus?id=${statusId}`);
  }
}
