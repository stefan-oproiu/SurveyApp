import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(
    private loginService: LoginService,
    private snackBar: MatSnackBar) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const result = this.loginService.isAdmin();
    if (result) {
      return result;
    }

    this.snackBar.open("Only admins can access this route", "", { duration: 3000 });
    this.loginService.redirectToLogin();
    return false;
  }
}
