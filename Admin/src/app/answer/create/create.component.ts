import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AnswerService } from '../answer.service';

@Component({
  selector: 'app-answer-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
  @Input() questionId: Number | undefined;
  @Output() isUpdatable: EventEmitter<any> = new EventEmitter();

  form: FormGroup;
  isSending = false;

  constructor(private answerService: AnswerService, private fb: FormBuilder) {
    this.form = this.fb.group({
      content: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  addHandler(): void {
    this.isSending = true;

    this.isUpdatable.emit();

    this.answerService.create({ content: this.form.value.content, questionId: this.questionId ? this.questionId : 0 }).subscribe((x) => {
      this.isSending = false;
    });
  }
}
