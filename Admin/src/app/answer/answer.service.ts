import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateAnswer } from '../shared/Models/Answers/ICreateAnswer';
import { IUpdateAnswer } from '../shared/Models/Answers/IUpdateAnswer';

@Injectable({
  providedIn: 'root',
})
export class AnswerService {
  constructor(private http: HttpClient) {}

  getById(id: Number): Observable<any> {
    return this.http.get(`/answers?id=${id}`);
  }

  create(data: ICreateAnswer): Observable<any> {
    return this.http.post('/answers', data);
  }

  update(data: IUpdateAnswer): Observable<any> {
    return this.http.put('/answers', data);
  }

  delete(id: Number): Observable<any> {
    return this.http.delete(`/answers?id=${id}`);
  }
}
