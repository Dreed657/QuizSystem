import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IExam } from 'src/app/shared/Models/Exams/IExam';
import { ExamService } from '../exam.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss'],
})
export class UpdateComponent implements OnInit {
  exam: IExam | undefined;
  isLoading = false;

  form: FormGroup;
  isSending = false;

  constructor(
    private examService: ExamService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      id: [''],
      name: ['', [Validators.required]],
      entryCode: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.isLoading = true;
    const id = this.route.snapshot.params.id;

    this.examService.get(id).subscribe((x) => {
      this.exam = x;
      this.isLoading = false;

      this.form.patchValue(x);
    });
  }

  submitHandle(): void {
    const data = this.form.value;
    this.isSending = true;

    this.examService.update(data).subscribe((x) => {
      this.isSending = false;
      this.router.navigate([`/exams/${x.id}`]);
    });
  }
}
