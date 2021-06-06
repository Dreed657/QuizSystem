import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListingComponent } from './listing/listing.component';
import { ExamRouterModule } from './exam-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { ExamComponent } from './exam/exam.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { QuestionModule } from '../question/question.module';
import { CoreModule } from '../core/core.module';

@NgModule({
    declarations: [
        ListingComponent,
        CreateComponent,
        UpdateComponent,
        ExamComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        CoreModule,
        ReactiveFormsModule,
        QuestionModule,
        ExamRouterModule,
    ],
})
export class ExamModule {}
