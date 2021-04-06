import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ICreateQuestion } from '../shared/Models/Questions/ICreateQuestion';
import { IQuestion } from '../shared/Models/Questions/IQuestion';
import { IUpdateQuestion } from '../shared/Models/Questions/IUpdateQuestion';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<IQuestion[]> {
    return this.http.get<IQuestion[]>('/questions');
  }

  get(id: Number): Observable<IQuestion> {
    return this.http.get<IQuestion>(`/questions/${id}`);
  }

  create(data: ICreateQuestion): Observable<IQuestion> {
    console.log("Data: ", data);

    return this.http.post<IQuestion>('/questions', data);
  }

  update(data: IUpdateQuestion): Observable<IQuestion> {
    return this.http.put<IQuestion>('/questions', data);
  }

  delete(id: Number): Observable<any> {
    return this.http.delete(`/questions/${id}`);
  }
}
