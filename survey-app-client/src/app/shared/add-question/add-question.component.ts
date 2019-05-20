import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs';
import { QuestionResponse, QuestionType, QuestionRequest } from 'src/app/models/question.model';
import { QuestionService } from 'src/app/services/question.service';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.scss']
})
export class AddQuestionComponent implements OnInit {

  form: FormGroup;
  constructor(
    private dialogRef: MatDialogRef<AddQuestionComponent>,
    private questionService: QuestionService) { }

  ngOnInit() {
    this.form = new FormGroup({
      text: new FormControl(''),
      file: new FormControl(null),
      choices: new FormArray([
        new FormGroup({ text: new FormControl('') }),
        new FormGroup({ text: new FormControl('') })]),
      type: new FormControl(false)
    });


  }

  addChoice() {
    let choices = this.form.get('choices') as FormArray;
    choices.push(new FormGroup({ text: new FormControl('') }));
  }

  removeChoice(index: number) {
    let choices = this.form.get('choices') as FormArray;
    choices.removeAt(index);
  }

  onSubmit() {
    var val = this.form.value;
    console.log(val);
    val.file = val.file.files ? val.file.files[0] : val.file;
    val.type = val.type ? QuestionType.multipleChoice : QuestionType.singleChoice;
    let model = val as QuestionRequest;
    this.questionService.postQuestion(model)
      .pipe(switchMap(q => this.questionService.updateQuestionImage(q.id, val.file)))
      .subscribe(response => this.dialogRef.close(response));
  }
}
