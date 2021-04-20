import { AxiosResponse } from 'axios';
import axiosInstance from '../utils/axiosUtils';

import IExam from '../models/IExam';
import IShortExam from '../models/IShortExam';

const API_URL = 'https://localhost:44369/api';

interface IFinish {
    score: number;
    correctAnswers: number;
    wrongAnswers: number;
    startTime: Date;
    endTime: Date;
}

class ExamService {
    getAll(): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IShortExam[]>(`${API_URL}/exams`);
    }

    getById(id: string): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IExam>(`${API_URL}/exams/${id}`);
    }

    start(examId: string): Promise<AxiosResponse<any>> {
        return axiosInstance.post<boolean>(`${API_URL}/exams/start?examId=${examId}`);
    }

    finish(examId: string): Promise<AxiosResponse<any>> {
        return axiosInstance.post<IExam>(`${API_URL}/exams/finish?examId=${examId}`);
    }
}

export default new ExamService();
