import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuestionResponse, QuestionRequest } from '../models/question.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private http: HttpClient) { }

  getQuestions(questionIds: number[] = []): Observable<QuestionResponse[]> {
    var params = new HttpParams();
    questionIds.forEach(id => {
      params = params.append('questionIds', `${id}`);
    });

    return this.http.get<QuestionResponse[]>(`${environment.api}/questions`, { params: params })
  }

  postQuestion(model: QuestionRequest): Observable<QuestionResponse> {
    return this.http.post<QuestionResponse>(`${environment.api}/questions`, model);
  }
}
