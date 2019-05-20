import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {
  userName: string;
  constructor(private loginService: LoginService) { }

  ngOnInit() {
    this.userName = this.loginService.getPayload().name;
  }

  logOut() {
    this.loginService.logOut();
  }

  get isAdmin() {
    return this.loginService.isAdmin();
  }

}
