import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import ILogin from 'src/app/shared/Models/Common/ILogin';
import IRegister from 'src/app/shared/Models/Common/IRegister';

const tokenStorageName = 'auth-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(data: ILogin): Observable<any> {
    return this.http.post('/identity/login', data);
  }

  register(data: IRegister): Observable<any> {
    return this.http.post('/identity/register', data);
  }

  setToken(token: string): void {
    localStorage.setItem(tokenStorageName, token);
  }

  getToken(): string | null {
    return localStorage.getItem(tokenStorageName);
  }

  removeToken(): void {
    localStorage.removeItem(tokenStorageName);
  }
}
