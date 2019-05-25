import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { SurveyService } from 'src/app/services/survey.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { QuestionResponse } from 'src/app/models/question.model';
import { SurveyRequest } from 'src/app/models/survey.model';

@Component({
  selector: 'app-add-survey',
  templateUrl: './add-survey.component.html',
  styleUrls: ['./add-survey.component.scss']
})
export class AddSurveyComponent implements OnInit {

  form: FormGroup;
  constructor(
    private dialogRef: MatDialogRef<AddSurveyComponent>,
    private surveyService: SurveyService,
    @Inject(MAT_DIALOG_DATA) public data: QuestionResponse[]) { }

  ngOnInit() {
    this.form = new FormGroup({
      name: new FormControl(),
      questionIds: new FormControl([])
    });
  }

  onSubmit() {
    let survey = this.form.value as SurveyRequest;
    this.surveyService.postSurvey(survey)
      .subscribe(res => this.dialogRef.close(res));
  }

}
