import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Register } from '../models/register.model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public signUp(model: Register): Observable<string> {
    return this.http.post<string>(`${environment.api}/auth/signup`, model)
      .pipe(tap(console.log));
  }

  public logIn(model: Login): Observable<string> {
    return this.http.post<string>(`${environment.api}/auth/token`, model);
  }
}
