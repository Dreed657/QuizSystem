import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from 'src/app/question/question.service';
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

    constructor(
        private examService: ExamService,
        private questionService: QuestionService,
        private route: ActivatedRoute,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.isLoading = true;
        const id = this.route.snapshot.params.id;

        this.examService.get(id).subscribe((x) => {
            this.exam = x;
            this.isLoading = false;
        });
    }

    deleteHandler(id: Number | undefined): void {
        if (id === undefined) {
            return;
        }

        this.examService.delete(id).subscribe((x) => {
            this.router.navigate(['/exams']);
        });
    }

    removeQuestionHandler(id: Number): void {
        this.questionService
            .removeQuestionExam({ examId: this.exam?.id, questionId: id })
            .subscribe();
    }
}
