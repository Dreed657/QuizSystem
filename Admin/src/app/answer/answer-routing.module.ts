import { Routes, RouterModule } from '@angular/router';
import { AnswerComponent } from './answer/answer.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
    {
        path: 'answers',
        children: [
            {
                path: 'update/:id',
                component: UpdateComponent,
            },
            {
                path: ':id',
                component: AnswerComponent,
            },
        ],
    },
];

export const AnswerRouterModule = RouterModule.forChild(routes);
