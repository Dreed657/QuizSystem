import { Component, OnInit } from '@angular/core';
import IUser from 'src/app/shared/Models/Users/IUser';
import { UserService } from '../user.service';

@Component({
    selector: 'app-listing',
    templateUrl: './listing.component.html',
    styleUrls: ['./listing.component.scss'],
})
export class ListingComponent implements OnInit {
    users: IUser[] = [];
    isLoading = false;

    constructor(private userService: UserService) {}

    ngOnInit(): void {
      this.isLoading = true;

      this.userService.getAll().subscribe(x => {
        this.users = x;
        this.isLoading = false;
      })
    }
}
