import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IQuestion } from 'src/app/shared/Models/Questions/IQuestion';
import { QuestionService } from '../question.service';

@Component({
    selector: 'app-update',
    templateUrl: './update.component.html',
    styleUrls: ['./update.component.scss'],
})
export class UpdateComponent implements OnInit {
    question: IQuestion | undefined;
    isLoading = false;

    form: FormGroup;
    isSending = false;

    constructor(
        private questionService: QuestionService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute
    ) {
        this.form = this.fb.group({
            id: [''],
            title: ['', [Validators.required]],
            type: [0, [Validators.required]],
        });
    }

    ngOnInit(): void {
        this.isLoading = true;
        const id = this.route.snapshot.params.id;

        this.questionService.get(id).subscribe((x) => {
            this.question = x;
            this.isLoading = false;

            this.form.patchValue(x);
        });
    }

    submitHandle(): void {
        const data = this.form.value;
        this.isSending = true;

        this.questionService.update(data).subscribe((x) => {
            this.isSending = false;
            this.router.navigate([`/questions/${x.id}`]);
        });
    }
}
