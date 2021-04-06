import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { ListingComponent } from './listing/listing.component';
import { QuestionComponent } from './question/question.component';
import { SharedModule } from '../shared/shared.module';
import { QuestionRouterModule } from './question-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [CreateComponent, UpdateComponent, ListingComponent, QuestionComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    QuestionRouterModule
  ]
})
export class QuestionModule { }
