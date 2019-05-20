import { Component } from '@angular/core';
import { Handler } from './services/error-handler.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'survey-app-client';
  constructor(private handler: Handler) {}
}
