import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IAnswer } from 'src/app/shared/Models/Answers/IAnswer';
import { AnswerService } from '../answer.service';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.scss'],
})
export class AnswerComponent implements OnInit {
  answer: IAnswer | undefined;
  isLoading = false;

  constructor(
    private answerService: AnswerService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.isLoading = true;
    let id = this.route.snapshot.params.id;

    this.answerService.getById(id).subscribe((x) => {
      this.answer = x;
      this.isLoading = false;
    });
  }
}
