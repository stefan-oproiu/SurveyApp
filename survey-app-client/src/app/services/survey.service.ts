import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SurveyResponse, SurveyRequest } from '../models/survey.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  constructor(private http: HttpClient) { }

  getSurveys(): Observable<SurveyResponse[]> {
    return this.http.get<SurveyResponse[]>(`${environment.api}/surveys`);
  }

  getSurveyById(id: number): Observable<SurveyResponse> {
    return this.http.get<SurveyResponse>(`${environment.api}/surveys/${id}`);
  }

  postSurvey(model: SurveyRequest): Observable<SurveyResponse> {
    return this.http.post<SurveyResponse>(`${environment.api}/surveys`, model);
  }
}
