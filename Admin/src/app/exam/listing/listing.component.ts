import { Component, OnInit } from '@angular/core';
import { IExam } from 'src/app/shared/Models/Exams/IExam';
import { IShortExam } from 'src/app/shared/Models/Exams/IShortExam';
import { ExamService } from '../exam.service';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss']
})
export class ListingComponent implements OnInit {

  exams: IShortExam[] | undefined;
  isLoading = false;

  constructor(private examsService: ExamService) { }

  ngOnInit(): void {
    this.isLoading = true;

    this.examsService.getAll().subscribe(x => {
      this.isLoading = false;
      this.exams = x;
    })
  }

}
