import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionComponent } from './question/question.component';
import { MaterialModule } from '../material/material.module';
import { AddQuestionComponent } from './add-question/add-question.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddButtonComponent } from './add-button/add-button.component';
import { AddSurveyComponent } from './add-survey/add-survey.component';

@NgModule({
  declarations: [QuestionComponent, AddQuestionComponent, AddButtonComponent, AddSurveyComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports:[QuestionComponent, AddQuestionComponent, AddButtonComponent, AddSurveyComponent]
})
export class SharedModule { }
