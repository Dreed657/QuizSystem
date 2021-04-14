import authHeader from '../utils/authHeader';

const tokenStorageName = 'auth_token';

class TokenService {
    checkToken(): void {
        console.log(authHeader());
    }

    removeToken(): void {
        localStorage.removeItem(tokenStorageName);
    }

    setToken(token: string): void {
        localStorage.setItem(tokenStorageName, token);
    }

    getToken(): string {
        let value = localStorage.getItem(tokenStorageName);
        return  value ? value : '';
    }
}

export default new TokenService();