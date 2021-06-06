import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../core/guards/auth.guard';
import { CreateComponent } from './create/create.component';
import { ExamComponent } from './exam/exam.component';
import { ListingComponent } from './listing/listing.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
    {
        path: 'exams',
        canActivateChild: [AuthGuard],
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: ListingComponent,
            },
            {
                path: 'update/:id',
                component: UpdateComponent,
            },
            {
                path: 'create',
                component: CreateComponent,
            },
            {
                path: ':id',
                component: ExamComponent,
            },
        ],
    },
];

export const ExamRouterModule = RouterModule.forChild(routes);
