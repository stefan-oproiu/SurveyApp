import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormArray, FormGroup, FormControl } from '@angular/forms';
import { SurveyService } from 'src/app/services/survey.service';
import { SurveyResponse } from 'src/app/models/survey.model';
import { QuestionResponse } from 'src/app/models/question.model';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.scss']
})
export class SurveyComponent implements OnInit {

  form: FormGroup;
  survey: SurveyResponse;
  constructor(
    private route: ActivatedRoute,
    private surveyService: SurveyService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = +params['id'];
      this.surveyService.getSurveyById(id).subscribe(res => {
        this.survey = res;
        let questions = new FormArray([]);
        this.survey.questions.forEach(q => {
          let choices = new FormArray([]);
          q.choices.forEach(c => {
            choices.push(new FormControl(c));
          });
          questions.push(new FormGroup({
            text: new FormControl(q.text),
            choices: choices
          }));
        });

        this.form = new FormGroup({
          questions: questions
        });
        console.log(this.form.value);
      })
    });
  }

  private addQuestion(question: QuestionResponse) {
    var questionsForm = (this.form.get('questions') as FormArray).controls;

  }

}
