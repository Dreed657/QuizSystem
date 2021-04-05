import { Routes, RouterModule } from "@angular/router";
import { CreateComponent } from "./create/create.component";
import { ExamComponent } from "./exam/exam.component";
import { ListingComponent } from "./listing/listing.component";
import { UpdateComponent } from "./update/update.component";

const routes: Routes = [
    {
        path: 'exams',
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: ListingComponent
            },
            {
                path: 'update',
                pathMatch: 'full',
                component: UpdateComponent
            },
            {
                path: 'create',
                pathMatch: 'full',
                component: CreateComponent
            },
            {
                path: ':id',
                component: ExamComponent
            }
        ]
    }
];

export const ExamRouterModule = RouterModule.forChild(routes);