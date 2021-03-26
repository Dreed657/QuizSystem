import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListingComponent } from './listing/listing.component';
import { ExamRouterModule } from './exam-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { ExamComponent } from './exam/exam.component';



@NgModule({
  declarations: [ListingComponent, CreateComponent, UpdateComponent, ExamComponent],
  imports: [
    CommonModule,
    ExamRouterModule
  ]
})
export class ExamModule { }
