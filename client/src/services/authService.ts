import axios, { AxiosResponse } from 'axios';

import authHeader from '../utils/authHeader';

const API_URL = 'https://localhost:44369/api';
const tokenStorageName = 'auth_token';

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
    checkToken(): void {
        console.log(authHeader());
    }

    setToken(token: string): void {
        localStorage.setItem(tokenStorageName, token);
    }

    getToken(): string {
        let value = localStorage.getItem(tokenStorageName);
        return  value ? value : '';
    }

    login(data: ILogin): Promise<AxiosResponse<any>> {
        return axios.post(`${API_URL}/identity/login`, data);
    }

    register(data: IRegister): Promise<AxiosResponse<any>> {
        return axios.post(`${API_URL}/identity/register`, data);
    }
}

export default new authService();
