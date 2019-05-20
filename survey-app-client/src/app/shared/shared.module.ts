import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionComponent } from './question/question.component';
import { MaterialModule } from '../material/material.module';
import { AddQuestionComponent } from './add-question/add-question.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [QuestionComponent, AddQuestionComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports:[QuestionComponent, AddQuestionComponent]
})
export class SharedModule { }
