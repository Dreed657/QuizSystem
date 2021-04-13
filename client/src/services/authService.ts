import axios, { AxiosResponse } from 'axios';

import authHeader from '../utils/authHeader';

const API_URL = "https://localhost:44369/api";

class authService {
    checkToken(): void {
        console.log(authHeader());
    }

    login(data: any): Promise<AxiosResponse<any>> {
        return axios.post(`${API_URL}/identity/login`, data);
    }

    register(data: any): Promise<AxiosResponse<any>> {
        return axios.post(`${API_URL}/identity/register`, data);
    }
}

export default new authService();