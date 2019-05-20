import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SubmissionResponse, SubmissionRequest } from '../models/submission.model';
import { HttpParams, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubmissionService {

  constructor(private http: HttpClient) { }

  getSubmissions(userId?: number): Observable<SubmissionResponse[]> {
    var params = new HttpParams();
    if (userId)
      params = params.append("userId", `${userId}`);

    return this.http.get<SubmissionResponse[]>(`${environment.api}/submissions`, { params: params });
  }

  getSubmission(submissionId: number): Observable<SubmissionResponse> {
    return this.http.get<SubmissionResponse>(`${environment.api}/submissions/${submissionId}`);
  }

  postSubmission(model: SubmissionRequest): Observable<SubmissionResponse> {
    return this.http.post<SubmissionResponse>(`${environment.api}/submissions`, model);
  }

}
