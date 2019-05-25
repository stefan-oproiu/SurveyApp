import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { QuestionsComponent } from './questions/questions.component';
import { SubmissionsComponent } from './submissions/submissions.component';
import { SurveysComponent } from './surveys/surveys.component';
import { SurveyComponent } from './survey/survey.component';
import { MaterialModule } from '../material/material.module';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AddQuestionComponent } from '../shared/add-question/add-question.component';
import { AddSurveyComponent } from '../shared/add-survey/add-survey.component';

@NgModule({
  declarations: [ShellComponent, QuestionsComponent, SubmissionsComponent, SurveysComponent, SurveyComponent],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    SharedModule
  ],
  entryComponents: [AddQuestionComponent, AddSurveyComponent]
})
export class ShellModule { }
