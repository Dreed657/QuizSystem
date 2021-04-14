import { AxiosResponse } from 'axios';

import axiosInstance from '../utils/axiosUtils';

const API_URL = 'https://localhost:44369/api';

interface IExam {
    id: number,
    name: string,
    questions: number
}

class ExamService {
    getAll(): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IExam[]>(`${API_URL}/exams`);
    }
}

export default new ExamService();
