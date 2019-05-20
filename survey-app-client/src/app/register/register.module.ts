import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [RegisterComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule
  ]
})
export class RegisterModule { }
