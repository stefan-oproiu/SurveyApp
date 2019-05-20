import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class Handler {

  static SnackBar: MatSnackBar;
  constructor(private snackBar: MatSnackBar) {
    if (!Handler.SnackBar) {
      Handler.SnackBar = this.snackBar;
    }
  }

  static handle(error: HttpErrorResponse) {
    console.log(error);
    Handler.SnackBar.open(error.error, '', { duration: 3000 });
  }
}
