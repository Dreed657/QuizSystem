import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateExam } from '../shared/Models/Exams/ICreateExam';
import { IExam } from '../shared/Models/Exams/IExam';
import { IShortExam } from '../shared/Models/Exams/IShortExam';
import { IUpdateExam } from '../shared/Models/Exams/IUpdateExam';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  constructor(private http: HttpClient) { }

  get(id: Number): Observable<IExam> {
    return this.http.get<IExam>(`/exams/${id}`);
  }

  getAll(): Observable<IShortExam[]> {
    return this.http.get<IShortExam[]>('/exams');
  }

  create(data: ICreateExam): Observable<IExam> {
    return this.http.post<IExam>('/exams', data);
  }

  update(data: IUpdateExam): Observable<IExam> {
    return this.http.put<IExam>('/exams', data);
  }
  
  delete(id: Number): Observable<any> {
    return this.http.delete(`/exams/${id}`);
  }
  
}
