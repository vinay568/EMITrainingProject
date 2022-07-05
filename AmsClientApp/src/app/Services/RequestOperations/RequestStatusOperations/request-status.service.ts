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
export class RequestStatusService {
  statusUrl = environment.requestStatusUrl;

  constructor(private http : HttpClient) { }

  public setApprovedStatus(requestId:any, request:any):Observable<RequestsModel> {
    return this.http.put<RequestsModel>(`${this.statusUrl}/SetApprovedStatus?id=${requestId}`, request);
  }

  public setRejectedStatus(requestId:any, request:any):Observable<RequestsModel> {
    return this.http.put<RequestsModel>(`${this.statusUrl}/SetRejectedStatus?id=${requestId}`, request);
  }

  public setForwardedStatus(requestId:any, request:any):Observable<RequestsModel> {
    request.forwardedTo = sessionStorage.getItem('managerId');
    return this.http.put<RequestsModel>(`${this.statusUrl}/SetForwardedStatus?id=${requestId}`, request);
  }

  public setCompletedStatus(requestId:any, request:any):Observable<RequestsModel> {
    return this.http.put<RequestsModel>(`${this.statusUrl}/SetCompletedStatus?id=${requestId}`, request);
  }
}
