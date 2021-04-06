import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { QuestionService } from '../question.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
  form: FormGroup;
  isSending = false;

  constructor(
    private questionService: QuestionService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.form = this.fb.group({
      title: ['', [Validators.required]],
      type: [0, [Validators.required]],
    });
  }

  ngOnInit(): void {}

  submitHandle(): void {
    const data = this.form.value;
    this.isSending = true;

    this.questionService.create(data).subscribe((x) => {
      this.isSending = false;
      this.router.navigate([`/questions/${x.id}`]);
    });
  }
}
