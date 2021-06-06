import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import IUser from '../shared/Models/Users/IUser';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<IUser[]> {
        return this.http.get<IUser[]>('/users');
    }

    getById(id: string): Observable<any> {
        return this.http.get<IUser>(`/users/${id}`);
    }
}
