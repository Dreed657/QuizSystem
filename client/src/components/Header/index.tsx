import React from 'react';
import { useHistory } from 'react-router-dom';

import { Header, Navbar, Nav, Dropdown, Icon } from 'rsuite';

const MasterHeader = () => {
    const history = useHistory();

    return (
        <Header>
            <Navbar appearance="inverse">
                <Navbar.Header></Navbar.Header>
                <Navbar.Body>
                    <Nav>
                        <Nav.Item
                            icon={<Icon icon="home" />}
                            onSelect={() => history.push('/')}
                        >
                            Home
                        </Nav.Item>
                        <Nav.Item onSelect={() => history.push('/login')}>
                            Login
                        </Nav.Item>
                        <Nav.Item onSelect={() => history.push('/register')}>
                            Register
                        </Nav.Item>
                        <Dropdown title="About">
                            <Dropdown.Item>Company</Dropdown.Item>
                            <Dropdown.Item>Team</Dropdown.Item>
                            <Dropdown.Item>Contact</Dropdown.Item>
                        </Dropdown>
                    </Nav>
                    <Nav pullRight>
                        <Dropdown title="Settings" icon={<Icon icon="cog" />}>
                            <Dropdown.Item>Theme</Dropdown.Item>
                            <Dropdown.Item>LogOut</Dropdown.Item>
                        </Dropdown>
                    </Nav>
                </Navbar.Body>
            </Navbar>
        </Header>
    );
};

export default MasterHeader;
