import { Routes, RouterModule } from "@angular/router";
import { ListingComponent } from "./listing/listing.component";

const routes: Routes = [
    {
        path: 'exam',
        children: [
            {
                path: '',
                pathMatch: 'full',
                component: ListingComponent
            }
        ]
    }
];

export const ExamRouterModule = RouterModule.forChild(routes);