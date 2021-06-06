import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICreateAnswer } from 'src/app/shared/Models/Answers/ICreateAnswer';
import { AnswerService } from '../answer.service';

@Component({
    selector: 'app-answer-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
    @Input() questionId: Number;
    @Output() isUpdated: EventEmitter<any> = new EventEmitter();

    form: FormGroup;
    isSending = false;

    constructor(private answerService: AnswerService, private fb: FormBuilder) {
        this.questionId = 0;

        this.form = this.fb.group({
            isCorrect: [false],
            content: ['', [Validators.required]],
        });
    }

    ngOnInit(): void {}

    addHandler(): void {
        this.isSending = true;

        this.isUpdated.emit();

        let data: ICreateAnswer = {
            content: this.form.value.content,
            questionId: this.questionId,
            isCorrect: this.form.value.isCorrect,
        };

        this.answerService.create(data).subscribe((x) => {
            this.isSending = false;
        });
    }
}
