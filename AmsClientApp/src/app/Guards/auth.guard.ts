/* eslint-disable consistent-return */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable eqeqeq */
/* eslint-disable import/no-unresolved */
/* eslint-disable class-methods-use-this */
/* eslint-disable import/prefer-default-export */
/* eslint-disable no-unused-vars */
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { LoginServiceService } from '../Services/Authentication/login-service.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  roleId = sessionStorage.getItem('role');

  constructor(private loginService : LoginServiceService, private route : Router) {}

  canActivate(
    _route: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot,
  ): boolean {
    if (sessionStorage.getItem('isLoggedIn') == 'true') {
      return true;
    }

    this.route.navigate(['login']);
    return false;
  }
}
