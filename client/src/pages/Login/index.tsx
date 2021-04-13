import React from 'react';

import { Button } from 'rsuite';

import AuthService from '../../services/authService';

const LoginPage = () => {

    return (
        <div>
            <h3>Login Page.</h3>
            <Button appearance="primary" color="green" onClick={() => {
                AuthService.checkToken();
            }}>Test me</Button>
        </div>
    )
}

export default LoginPage;