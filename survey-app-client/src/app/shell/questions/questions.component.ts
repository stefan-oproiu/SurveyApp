import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/services/question.service';
import { QuestionResponse } from 'src/app/models/question.model';
import { MatDialog } from '@angular/material';
import { AddQuestionComponent } from 'src/app/shared/add-question/add-question.component';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnInit {

  questions: QuestionResponse[];
  constructor(
    private questionService: QuestionService,
    private matDialog: MatDialog) { }

  ngOnInit() {
    this.questionService.getQuestions().subscribe(
      data => this.questions = data
    )
  }

  addQuestion() {
    let dialogRef = this.matDialog.open(AddQuestionComponent)
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        this.questions.push(data);
        console.log(data);
      }
    });
  }

}
