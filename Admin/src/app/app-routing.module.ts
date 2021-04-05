import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ErrorComponent } from './shared/error/error.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: '**',
    component: ErrorComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);