import axios, { AxiosResponse } from 'axios';

import authHeader from '../utils/authHeader';

const API_URL = 'https://localhost:44369/api';

interface IExam {
    id: number,
    name: string,
    questions: number
}

class ExamService {
    getAll(): Promise<AxiosResponse<any>> {
        return axios.get<IExam[]>(`${API_URL}/exams`, { headers: authHeader() });
    }
}

export default new ExamService();
