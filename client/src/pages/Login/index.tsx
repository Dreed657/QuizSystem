import React from 'react';
import { useState } from 'react';
import { useHistory } from 'react-router';

import {
    Button,
    ButtonToolbar,
    Container,
    Content,
    ControlLabel,
    FlexboxGrid,
    Form,
    FormControl,
    FormGroup,
    Header,
    Navbar,
    Panel,
} from 'rsuite';

import AuthService from '../../services/authService';

const LoginPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const history = useHistory();

    const handleSubmit = (e: any) => {
        e.preventDefault();

        AuthService.login({ email, password })
            .then((res) => {
                console.log(res);
                AuthService.setToken(res.data.token);
                history.push('/');
            })
            .catch((e) => {
                console.error(e);
            });
    };

    return (
        <Container appearance="inverse">
            <Header>
                <Navbar appearance="inverse">
                    <Navbar.Header>
                        <p className="navbar-brand logo">Brand</p>
                    </Navbar.Header>
                </Navbar>
            </Header>
            <Content style={{ marginTop: 100 }}>
                <FlexboxGrid justify="center">
                    <FlexboxGrid.Item colspan={12}>
                        <Panel header={<h3>Login</h3>} bordered>
                            <Form fluid>
                                <FormGroup>
                                    <ControlLabel>Email address</ControlLabel>
                                    <FormControl
                                        name="email"
                                        type="email"
                                        onChange={(value) => setEmail(value)}
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <ControlLabel>Password</ControlLabel>
                                    <FormControl
                                        name="password"
                                        type="password"
                                        onChange={(value) => setPassword(value)}
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <ButtonToolbar>
                                        <Button
                                            appearance="primary"
                                            onClick={handleSubmit}
                                        >
                                            Sign in
                                        </Button>
                                        <Button appearance="link">
                                            Forgot password?
                                        </Button>
                                    </ButtonToolbar>
                                </FormGroup>
                            </Form>
                        </Panel>
                    </FlexboxGrid.Item>
                </FlexboxGrid>
            </Content>
        </Container>
    );
};

export default LoginPage;
