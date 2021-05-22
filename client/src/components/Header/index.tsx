import React from 'react';
import { useHistory } from 'react-router-dom';

import { Header, Navbar, Nav, Dropdown, Icon } from 'rsuite';
import tokenService from '../../services/tokenService';

const MasterHeader = () => {
    const history = useHistory();

    const authenticated = tokenService.getToken();

    const logoutHandler = () => {
        tokenService.removeToken();
        history.push('login');
    };

    return (
        <Header>
            <Navbar appearance="inverse">
                <Navbar.Header></Navbar.Header>
                <Navbar.Body>
                    {authenticated !== '' ? (
                        <Nav>
                            <Nav.Item
                                icon={<Icon icon="home" />}
                                onSelect={() => history.push('/')}
                            >
                                Home
                            </Nav.Item>
                            <Dropdown title="About">
                                <Dropdown.Item>Company</Dropdown.Item>
                                <Dropdown.Item
                                    onSelect={() =>
                                        history.push('asffshfgjhfj')
                                    }
                                >
                                    Error page
                                </Dropdown.Item>
                                <Dropdown.Item>Contact</Dropdown.Item>
                            </Dropdown>
                        </Nav>
                    ) : (
                        <Nav>
                            <Nav.Item onSelect={() => history.push('/login')}>
                                Login
                            </Nav.Item>
                            <Nav.Item
                                onSelect={() => history.push('/register')}
                            >
                                Register
                            </Nav.Item>
                        </Nav>
                    )}
                    <Nav pullRight>
                        <Dropdown title="Settings" icon={<Icon icon="cog" />}>
                            <Dropdown.Item>Theme</Dropdown.Item>
                            <Dropdown.Item onSelect={logoutHandler}>
                                LogOut
                            </Dropdown.Item>
                        </Dropdown>
                    </Nav>
                </Navbar.Body>
            </Navbar>
        </Header>
    );
};

export default MasterHeader;
