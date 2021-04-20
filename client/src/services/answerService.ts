import { AxiosResponse } from 'axios';

import axiosInstance from '../utils/axiosUtils';

const API_URL = 'https://localhost:44369/api';

interface ISaveAnswer {
    questionId: number;
    answerId: number;
    examId: number;
}

class answerService {
    saveAnswer(data: ISaveAnswer): Promise<AxiosResponse<any>> {
        return axiosInstance.post(`${API_URL}/answers/saveanswer`, data);
    }
}

export default new answerService();
