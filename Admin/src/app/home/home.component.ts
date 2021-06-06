import { Component, OnInit } from '@angular/core';
import { StatisticsService } from '../core/services/statistics.service';
import IBaseStats from '../shared/Models/Statistics/IBaseStats';
import ITopExams from '../shared/Models/Statistics/ITopExams';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
    data: IBaseStats | undefined;
    isLoading = false;

    topExams: ITopExams[] | undefined;

    constructor(private statistics: StatisticsService) {}

    ngOnInit(): void {
        this.isLoading = true;
        this.statistics.getBaseData().subscribe((x) => {
            this.data = x;
            this.isLoading = false;
        });

        this.statistics.getTopExams(5).subscribe((x) => {
            this.topExams = x;
        });
    }
}
