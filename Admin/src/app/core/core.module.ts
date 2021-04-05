import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { appInterceptorProvider } from './app.interceptor';



@NgModule({
  declarations: [HeaderComponent, SidebarComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  providers: [
    appInterceptorProvider
  ],
  exports: [HeaderComponent, SidebarComponent]
})
export class CoreModule { }
