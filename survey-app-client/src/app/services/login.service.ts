import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtPayload } from '../models/jwt-payload.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private router: Router,
    public jwtHelper: JwtHelperService) { }

  isLoggedIn(): boolean {
    return !this.jwtHelper.isTokenExpired();
  }

  isAdmin(): boolean {
    const payload = this.getPayload();
    return this.isLoggedIn() && payload.role.toLowerCase() === 'admin';
  }

  getPayload(): JwtPayload {
    return this.jwtHelper.decodeToken() as JwtPayload;
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
    this.router.navigate(['login']);
  }

  logOut(): void {
    this.removeToken();
    this.redirectToLogin();
  }

  removeToken(): void {
    localStorage.removeItem('token');
  }

  redirectToLogin(): void {
    this.router.navigate(['login']);
  }

  redirectToSurveys(): void {
    this.router.navigate(['surveys']);
  }
}
