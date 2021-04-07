import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ExamModule } from './exam/exam.module';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './home/home.component';
import { QuestionModule } from './question/question.module';
import { AnswerModule } from './answer/answer.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    SharedModule,
    ExamModule,
    QuestionModule,
    AnswerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
