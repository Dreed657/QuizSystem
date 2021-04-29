import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private http: HttpClient) { }

  getBaseData(): Observable<any> {
    return this.http.get('/Statistics/GetBaseStats');
  }

  getTopExams(count: number): Observable<any> {
    return this.http.get(`/Statistics/GetTopExams?count=${count}`);
  }
}
