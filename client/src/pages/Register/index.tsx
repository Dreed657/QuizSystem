import React, { useState } from 'react';
import { useHistory } from 'react-router';

import {
    Container,
    Header,
    Navbar,
    Content,
    FlexboxGrid,
    Panel,
    Form,
    FormGroup,
    ControlLabel,
    FormControl,
    ButtonToolbar,
    Button,
} from 'rsuite';

import AuthService from '../../services/authService';

const RegisterPage = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const history = useHistory();

    const redirectToRegister = () => {
        history.push('/login');
    };

    const handleSubmit = (e: any) => {
        e.preventDefault();

        AuthService.register({ username, password, email })
            .then((res) => {
                console.log(res);
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
                        <Panel header={<h3>Register</h3>} bordered>
                            <Form fluid>
                                <FormGroup>
                                    <ControlLabel>Username</ControlLabel>
                                    <FormControl
                                        name="username"
                                        type="text"
                                        onChange={(value) =>
                                            setUsername(value)
                                        }
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <ControlLabel>Email address</ControlLabel>
                                    <FormControl
                                        name="name"
                                        type="email"
                                        onChange={(value) =>
                                            setEmail(value)
                                        }
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <ControlLabel>Password</ControlLabel>
                                    <FormControl
                                        name="password"
                                        type="password"
                                        onChange={(value) =>
                                            setPassword(value)
                                        }
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <ButtonToolbar>
                                        <Button
                                            appearance="primary"
                                            onClick={handleSubmit}
                                        >
                                            Sign up
                                        </Button>
                                        <Button
                                            appearance="link"
                                            onClick={redirectToRegister}
                                        >
                                            Already have an a account?
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

export default RegisterPage;
