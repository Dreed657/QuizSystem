import { AxiosResponse } from 'axios';

import axiosInstance from '../utils/axiosUtils';

const API_URL = 'https://localhost:44369/api';

class profileService {
    getProfile(): Promise<AxiosResponse<any>> {
        return axiosInstance.get(`${API_URL}/profile`);
    }
}

export default new profileService();