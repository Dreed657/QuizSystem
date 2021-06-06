import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
    hidden = false;

    constructor(private auth: AuthService, private router: Router) {}

    ngOnInit(): void {}

    logoutHandler(): void {
        this.auth.removeToken();
        this.router.navigate(['/login']);
    }
}
