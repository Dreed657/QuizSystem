import { Component, OnInit } from '@angular/core';
import { IQuestion } from 'src/app/shared/Models/Questions/IQuestion';
import { QuestionService } from '../question.service';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss']
})
export class ListingComponent implements OnInit {

  questions: IQuestion[] | undefined;
  isLoading = false;

  constructor(private questionService: QuestionService) { }

  ngOnInit(): void {
    this.isLoading = true;

    this.questionService.getAll().subscribe(x => {
      this.questions = x;
      this.isLoading = false;
    });
  }

}
