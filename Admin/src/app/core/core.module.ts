import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { appInterceptorProvider } from './app.interceptor';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [SidebarComponent, LoginComponent, RegisterComponent],
    imports: [CommonModule, RouterModule, ReactiveFormsModule],
    providers: [appInterceptorProvider],
    exports: [SidebarComponent, LoginComponent, RegisterComponent],
})
export class CoreModule {}
