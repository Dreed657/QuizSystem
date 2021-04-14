import { AxiosResponse } from 'axios';

import axiosInstance from '../utils/axiosUtils';

const API_URL = 'https://localhost:44369/api';

interface IRegister {
    username: string;
    email: string;
    password: string;
}

interface ILogin {
    email: string;
    password: string;
}

class authService {
    login(data: ILogin): Promise<AxiosResponse<any>> {
        return axiosInstance.post(`${API_URL}/identity/login`, data);
    }

    register(data: IRegister): Promise<AxiosResponse<any>> {
        return axiosInstance.post(`${API_URL}/identity/register`, data);
    }
}

export default new authService();
