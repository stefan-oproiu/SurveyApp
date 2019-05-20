import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { Register } from 'src/app/models/register.model';
import { LoginService } from 'src/app/services/login.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Handler } from 'src/app/services/error-handler.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  signUpForm: FormGroup;

  constructor(
    private userService: UserService,
    private loginService: LoginService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.signUpForm = new FormGroup({
      email: new FormControl('', [Validators.email, Validators.required]),
      name: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });

    this.loginService.removeToken();
  }

  get email() {
    return this.signUpForm.get('email');
  }
  get name() {
    return this.signUpForm.get('name');
  }
  get password() {
    return this.signUpForm.get('password');
  }

  onSubmit() {
    const model = this.signUpForm.value as Register;
    this.userService.signUp(model).pipe(tap(console.log)).subscribe(
      token => {
        this.loginService.saveToken(token.token)
        this.loginService.redirectToSurveys();
      },
      Handler.handle
    )
  }

}
