const tokenStorageName = 'auth_token';

const authHeader = () => {
    const token = localStorage.getItem(tokenStorageName);

    if (token) {
        return { 'Authorization': `Bearer ${token}`};
    } else {
        return {};
    }
}

export default authHeader;