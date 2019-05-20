import { Component, OnInit, Input } from '@angular/core';
import { QuestionResponse } from 'src/app/models/question.model';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {

  @Input() question: QuestionResponse;
  constructor() { }

  ngOnInit() {
  }

}
