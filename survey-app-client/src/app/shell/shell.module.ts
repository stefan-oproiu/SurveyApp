import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { QuestionsComponent } from './questions/questions.component';
import { SubmissionsComponent } from './submissions/submissions.component';
import { SurveysComponent } from './surveys/surveys.component';
import { SurveyComponent } from './survey/survey.component';

@NgModule({
  declarations: [ShellComponent, QuestionsComponent, SubmissionsComponent, SurveysComponent, SurveyComponent],
  imports: [
    CommonModule
  ]
})
export class ShellModule { }
