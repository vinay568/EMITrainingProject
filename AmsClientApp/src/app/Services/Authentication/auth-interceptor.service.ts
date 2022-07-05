/* eslint-disable class-methods-use-this */
/* eslint-disable no-empty-function */
/* eslint-disable import/prefer-default-export */
/* eslint-disable no-useless-constructor */
import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest,
}
  from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthInterceptorService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('token');

    if (!token) {
      return next.handle(req);
    }

    const req1 = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${token}`),
    });

    return next.handle(req1);
  }
}
