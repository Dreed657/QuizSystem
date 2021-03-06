import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../core/guards/auth.guard';
import { CreateComponent } from './create/create.component';
import { ListingComponent } from './listing/listing.component';
import { QuestionComponent } from './question/question.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
    {
        path: 'questions',
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
                component: QuestionComponent,
            },
        ],
    },
];

export const QuestionRouterModule = RouterModule.forChild(routes);
