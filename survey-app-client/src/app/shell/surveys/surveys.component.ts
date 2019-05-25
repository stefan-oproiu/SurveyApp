import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/services/question.service';
import { MatDialog } from '@angular/material';
import { QuestionResponse } from 'src/app/models/question.model';
import { AddSurveyComponent } from 'src/app/shared/add-survey/add-survey.component';
import { SurveyResponse } from 'src/app/models/survey.model';
import { tap } from 'rxjs/operators';
import { SurveyService } from 'src/app/services/survey.service';

@Component({
  selector: 'app-surveys',
  templateUrl: './surveys.component.html',
  styleUrls: ['./surveys.component.scss']
})
export class SurveysComponent implements OnInit {

  questions: QuestionResponse[];
  surveys: SurveyResponse[];

  questionsLoaded: boolean = false;
  surveysLoaded: boolean = false;
  constructor(
    private questionService: QuestionService,
    private surveyService: SurveyService,
    private matDialog: MatDialog) { }

  ngOnInit() {
    this.questionService.getQuestions()
      .pipe(tap(_ => this.questionsLoaded = true))
      .subscribe(res => this.questions = res);

    this.surveyService.getSurveys()
      .pipe(tap(_ => this.surveysLoaded))
      .subscribe(res => this.surveys = res)
  }

  addSurvey() {
    this.matDialog.open(AddSurveyComponent, {
      data: this.questions
    }).afterClosed().subscribe((res: SurveyResponse) => {
      if(!res)
        return;
      this.surveys.push(res);
    })
  }

}
