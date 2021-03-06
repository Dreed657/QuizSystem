import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { AnswerComponent } from './answer/answer.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AnswerRouterModule } from './answer-routing.module';
import { CoreModule } from '../core/core.module';

@NgModule({
    declarations: [CreateComponent, UpdateComponent, AnswerComponent],
    imports: [
        CommonModule,
        SharedModule,
        CoreModule,
        ReactiveFormsModule,
        AnswerRouterModule,
    ],
    exports: [CreateComponent],
})
export class AnswerModule {}
