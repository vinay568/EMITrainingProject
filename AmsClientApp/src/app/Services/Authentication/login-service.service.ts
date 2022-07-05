/* eslint-disable no-underscore-dangle */
/* eslint-disable no-unused-vars */
/* eslint-disable no-useless-constructor */
/* eslint-disable no-empty-function */
/* eslint-disable import/prefer-default-export */
/* eslint-disable import/no-unresolved */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject } from 'rxjs';
import { EmployeeModel } from 'src/app/Models/employee.model';
import { environment } from 'src/environments/environment';
import { AccountsModel } from '../../Models/accounts.model';

@Injectable({
  providedIn: 'root',
})
export class LoginServiceService {
  baseUrl = environment.loginUrl;

  private currentUser = new ReplaySubject<any>(1);

  currentUser$ = this.currentUser.asObservable();

  constructor(private _http : HttpClient) { }

  public loginUser(data:any): Observable<AccountsModel> {
    return this._http.post<AccountsModel>(this.baseUrl, data);
  }
}
