import axios from 'axios';

import TokenService from '../services/tokenService';

const axiosInstance = axios.create();

axiosInstance.interceptors.request.use(
    async (config) => {
        const token = TokenService.getToken();

        if (token) {
            config.headers = {
                Authorization: `Bearer ${token}`,
                Accept: 'application/json',
            };
        }

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

axiosInstance.interceptors.response.use(
    (res) => {
        return res;
    },
    async function (error) {
        if (error.response.status === 401) {
            TokenService.removeToken();

            //TODO: find react way of doing this
            window.location.href = "http://localhost:3000/login";
        }

        return Promise.reject(error);
    }
);

export default axiosInstance;
