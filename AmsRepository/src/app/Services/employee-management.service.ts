/* eslint-disable no-unused-vars */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
/* eslint-disable no-empty-function */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeModel } from '../Models/employee.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeManagementService {
  apiUrl = environment.employeesUrl;

  constructor(private http : HttpClient) { }

  public getEmployee():Observable<EmployeeModel[]> {
    return this.http.get<EmployeeModel[]>(this.apiUrl);
  }

  public getEmployeeById(id:any):Observable<EmployeeModel[]> {
    const url = `${this.apiUrl}/GetEmployeeById?id=${id}`;
    return this.http.get<EmployeeModel[]>(url);
  }
}
