import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ErrorComponent } from './shared/error/error.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/exam',
    pathMatch: 'full'
  },
  {
    path: '**',
    component: ErrorComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);