import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }

  logOut() {
    this.loginService.logOut();
  }

  get isAdmin() {
    return this.loginService.isAdmin();
  }

}
