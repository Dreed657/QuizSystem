import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListingComponent } from './listing/listing.component';
import { ExamRouterModule } from './exam-routing.module';



@NgModule({
  declarations: [ListingComponent],
  imports: [
    CommonModule,
    ExamRouterModule
  ]
})
export class ExamModule { }
