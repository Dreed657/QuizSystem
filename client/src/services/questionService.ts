import { AxiosResponse } from 'axios';
import IQuestion from '../models/IQuestion';
import axiosInstance from '../utils/axiosUtils';

const API_URL = 'https://localhost:44369/api';

class QuestionService {
    getById(id: number): Promise<AxiosResponse<any>> {
        return axiosInstance.get<IQuestion>(`${API_URL}/questions/${id}`);
    }
}

export default new QuestionService();
