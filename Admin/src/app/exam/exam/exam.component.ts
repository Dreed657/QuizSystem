import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IExam } from 'src/app/shared/Models/Exams/IExam';
import { ExamService } from '../exam.service';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.scss'],
})
export class ExamComponent implements OnInit {
  exam: IExam | undefined;
  isLoading = false;

  constructor(private exams: ExamService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.isLoading = true;
    let id = this.route.snapshot.params.id;

    this.exams.get(id).subscribe((x) => {
      this.exam = x;
      this.isLoading = false;
    });
  }
}
