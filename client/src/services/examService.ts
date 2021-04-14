import { AxiosResponse } from 'axios';
import axiosInstance from '../utils/axiosUtils';

import IExam from '../models/IExam';
import IShortExam from '../models/IShortExam';

const API_URL = 'https://localhost:44369/api';

class ExamService {
    getAll(): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IShortExam[]>(`${API_URL}/exams`);
    }

    getById(id: string): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IExam>(`${API_URL}/exams/${id}`);
    }
}

export default new ExamService();
