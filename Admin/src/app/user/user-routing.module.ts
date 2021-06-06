import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../core/guards/auth.guard';
import { ListingComponent } from './listing/listing.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
    {
        path: 'users',
        canActivateChild: [AuthGuard],
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: ListingComponent,
            },
            {
                path: ':id',
                component: UserComponent,
            },
        ],
    },
];

export const UserRouterModule = RouterModule.forChild(routes);
