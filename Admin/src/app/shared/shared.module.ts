import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { ErrorComponent } from './error/error.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [LoaderComponent, ErrorComponent],
    imports: [CommonModule, RouterModule],
    exports: [LoaderComponent, ErrorComponent],
})
export class SharedModule {}
