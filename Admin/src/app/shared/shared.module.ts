import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { ErrorComponent } from './error/error.component';



@NgModule({
  declarations: [LoaderComponent, ErrorComponent],
  imports: [
    CommonModule
  ],
  exports: [LoaderComponent, ErrorComponent]
})
export class SharedModule { }
