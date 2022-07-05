/* eslint-disable no-unused-vars */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FileUploadService {
  fileUploadApiUrl = environment.fileUploadUrl;

  constructor(private http : HttpClient) { }

  public uploadBill(billData:FormData):Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    const httpOptions = {
      headers,
    };
    return this.http.post<any>(this.fileUploadApiUrl, billData, httpOptions);
  }
}
