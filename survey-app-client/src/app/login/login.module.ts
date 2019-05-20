import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule
  ]
})
export class LoginModule { }
