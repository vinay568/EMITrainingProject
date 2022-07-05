/* eslint-disable no-empty-function */
/* eslint-disable no-param-reassign */
/* eslint-disable no-unused-vars */
/* eslint-disable no-underscore-dangle */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
/* eslint-disable import/no-unresolved */
import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RequestsModel } from '../../../Models/requests.model';

@Injectable({
  providedIn: 'root',
})
export class RequestService {
  private _refresh = new Subject<void>();

  get refreshRequired() {
    return this._refresh;
  }

  apiUrl = environment.apiRequestsUrl;

  myDate = new Date();

  constructor(private http: HttpClient, private datePipe: DatePipe) { }

  public getRequests():Observable<RequestsModel[]> {
    return this.http.get<RequestsModel[]>(`${this.apiUrl}/GetAllRequests`).pipe(
      tap(() => {
        this.refreshRequired.next();
      }),
    );
  }

  public getRequestById(id:any):Observable<RequestsModel> {
    const url = `${this.apiUrl}/GetRequestById?id=${id}`;
    return this.http.get<RequestsModel>(url);
  }

  public addRequest(data:any):Observable<RequestsModel> {
    data.employeeId = sessionStorage.getItem('USERID');
    data.approverId = sessionStorage.getItem('managerId');
    data.status = 1;
    return this.http.post<RequestsModel>(`${this.apiUrl}/AddNewRequest`, data).pipe(
      tap(() => {
        this.refreshRequired.next();
      }),
    );
  }

  public editRequest(data:any, id:any):Observable<RequestsModel> {
    return this.http.put<RequestsModel>(`${this.apiUrl}/UpdateRequest?id=${id}`, data).pipe(
      tap(() => {
        this.refreshRequired.next();
      }),
    );
  }

  public withDrawRequest(reqId:any):Observable<RequestsModel> {
    return this.http.delete<RequestsModel>(`${this.apiUrl}/DeleteRequest?id=${reqId}`).pipe(
      tap(() => {
        this.refreshRequired.next();
      }),
    );
  }
}
