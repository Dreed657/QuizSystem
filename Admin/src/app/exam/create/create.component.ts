import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ExamService } from '../exam.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
  form: FormGroup;
  isSending = false;

  constructor(
    private examService: ExamService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      entryCode: ['', [Validators.required]],
      duration: ['', [Validators.required, Validators.pattern('[0-9]{2}:[0-9]{2}:[0-9]{2}')]]
    });
  }

  ngOnInit(): void {}

  submitHandle(): void {
    const data = this.form.value;
    this.isSending = true;

    this.examService.create(data).subscribe((x) => {
      this.isSending = false;
      this.router.navigate([`exams/${x.id}`]);
    });
  }
}
