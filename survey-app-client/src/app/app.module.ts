import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { JwtModule } from '@auth0/angular-jwt';
import { ShellModule } from './shell/shell.module';
import { LoginModule } from './login/login.module';
import { RegisterModule } from './register/register.module';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ShellModule,
    LoginModule,
    RegisterModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        authScheme: 'Bearer ',
        whitelistedDomains: ['https://localhost:5001', 'https://localhost:6001']
      }
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
