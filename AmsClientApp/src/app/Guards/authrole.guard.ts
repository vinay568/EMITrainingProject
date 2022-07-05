/* eslint-disable no-useless-constructor */
/* eslint-disable no-empty-function */
/* eslint-disable no-unused-vars */
/* eslint-disable eqeqeq */
/* eslint-disable import/prefer-default-export */
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthroleGuard implements CanActivate {
  roleId = sessionStorage.getItem('role');

  constructor(private route : Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ): boolean {
    if (this.roleId == '1' || this.roleId == '2' || this.roleId == '3') {
      return true;
    }
    this.route.navigate(['login']);
    return false;
  }
}
