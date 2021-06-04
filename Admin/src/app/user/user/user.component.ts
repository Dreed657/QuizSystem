import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import IUser from 'src/app/shared/Models/Users/IUser';
import { UserService } from '../user.service';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit {
    user: IUser | null = null;
    isLoading = false;

    constructor(
        private userService: UserService,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.isLoading = true;
        const id = this.route.snapshot.params.id;

        this.userService.getById(id).subscribe((x) => {
            this.user = x;
            this.isLoading = false;
        });
    }
}
