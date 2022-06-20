/* eslint-disable no-underscore-dangle */
/* eslint-disable no-unused-vars */
/* eslint-disable no-useless-constructor */
/* eslint-disable no-empty-function */
/* eslint-disable import/prefer-default-export */
/* eslint-disable import/no-unresolved */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AccountsModel } from '../Models/accounts.model';

@Injectable({
  providedIn: 'root',
})
export class LoginServiceService {
  isLoggedIn = false;

  baseUrl = environment.loginUrl;

  constructor(private _http : HttpClient) { }

  public loginUser(data:any):Observable<AccountsModel> {
    this.isLoggedIn = true;
    return this._http.post<AccountsModel>(this.baseUrl, data);
  }
}
