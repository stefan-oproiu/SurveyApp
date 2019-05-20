import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { Login } from 'src/app/models/login.model';
import { LoginService } from 'src/app/services/login.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(
    private userService: UserService,
    private loginService: LoginService,
    private snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')
    });

    this.loginService.removeToken();
  }

  onSubmit() {
    const model = this.loginForm.value as Login;
    this.userService.logIn(model)
      .subscribe(
        token => {
          this.loginService.saveToken(token.access_token)
          this.loginService.redirectToMap();
        },
        (error: HttpErrorResponse) => {
          this.clearCredentials();
          this.snackBar.open("Bad credentials", "", { duration: 3000 })
        }
      )
  }

  private clearCredentials() {
    this.loginForm.reset();
  }

}
