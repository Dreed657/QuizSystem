import { Component, Input, OnInit } from '@angular/core';
import { IQuestion } from 'src/app/shared/Models/Questions/IQuestion';
import { QuestionService } from '../question.service';

@Component({
  selector: 'app-addexam',
  templateUrl: './addexam.component.html',
  styleUrls: ['./addexam.component.scss'],
})
export class AddexamComponent implements OnInit {
  @Input() examId: Number | undefined;
  questions: IQuestion[] | undefined;

  selectedId: Number | undefined;
  isLoading = false;

  constructor(private questionService: QuestionService) {}

  ngOnInit(): void {
    this.questionService
      .getAllAddable(!this.examId ? 0 : this.examId)
      .subscribe((x) => {
        this.questions = x;

        this.selectedId = x[0].id;
      });
  }

  addHandler(): void {
    this.isLoading = true;

    let data = { examId: this.examId, questionId: this.selectedId };
    this.questionService.addQuestionExam(data).subscribe((x) => {
      this.isLoading = false;
    });
  }

  changeQuestion(e: any) {
    this.selectedId = e.target.value;
  }
}
