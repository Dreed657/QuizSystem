import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
    providedIn: 'root',
})
export class AuthGuard implements CanActivate, CanActivateChild {
    constructor(private auth: AuthService, private router: Router) {}

    canActivate(): Observable<boolean> | boolean {
        var token = this.auth.getToken();

        if (token) {
            return true;
        }

        this.router.navigate(['/login']);
        return false;
    }

    canActivateChild(): Observable<boolean> | boolean {
        var token = this.auth.getToken();

        if (token) {
            return true;
        }

        this.router.navigate(['/login']);
        return false;
    }
}
