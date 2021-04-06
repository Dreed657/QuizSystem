import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IQuestion } from 'src/app/shared/Models/Questions/IQuestion';
import { QuestionService } from '../question.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss'],
})
export class QuestionComponent implements OnInit {
  question: IQuestion | undefined;
  isLoading = false;

  constructor(
    private questionServices: QuestionService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.params.id;

    this.questionServices.get(id).subscribe((x) => {
      this.question = x;
      this.isLoading = false;
    });
  }

  deleteHandler(id: Number | undefined): void {
    if (id === undefined) {
      return;
    }

    this.questionServices.delete(id).subscribe(x => {
      this.router.navigate(['/questions']);
    });
  }
}
