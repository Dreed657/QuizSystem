import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Sidenav, Nav, Icon, Dropdown, Sidebar, Navbar } from 'rsuite';

const headerStyles: any = {
    padding: 18,
    fontSize: 16,
    height: 56,
    background: '#34c3ff',
    color: ' #fff',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
};

const iconStyles: any = {
    width: 56,
    height: 56,
    lineHeight: '56px',
    textAlign: 'center',
};

const NavToggle = ({ expand, onChange }: any) => {
    return (
        <Navbar appearance="subtle" className="nav-toggle">
            <Navbar.Body>
                <Nav>
                    <Dropdown
                        placement="topStart"
                        trigger="click"
                        renderTitle={(children) => {
                            return <Icon style={iconStyles} icon="cog" />;
                        }}
                    >
                        <Dropdown.Item>Help</Dropdown.Item>
                        <Dropdown.Item>Settings</Dropdown.Item>
                        <Dropdown.Item>Sign out</Dropdown.Item>
                    </Dropdown>
                </Nav>

                <Nav pullRight>
                    <Nav.Item
                        onClick={onChange}
                        style={{ width: 56, textAlign: 'center' }}
                    >
                        <Icon icon={expand ? 'angle-left' : 'angle-right'} />
                    </Nav.Item>
                </Nav>
            </Navbar.Body>
        </Navbar>
    );
};

const ExamSidebar = () => {
    const [expand, setExpand] = useState(true);

    const handleToggle = () => {
        setExpand(!expand);
    };

    return (
        <Sidebar
            style={{ display: 'flex', flexDirection: 'column' }}
            width={expand ? 260 : 56}
            collapsible
        >
            <Sidenav
                expanded={expand}
                defaultOpenKeys={['3']}
                appearance="subtle"
            >
                <Sidenav.Header>
                    <Link to="/">
                        <div style={headerStyles}>
                            <Icon
                                icon="logo-analytics"
                                size="lg"
                                style={{ verticalAlign: 0 }}
                            />
                            <span style={{ marginLeft: 12 }}> BRAND</span>
                        </div>
                    </Link>
                </Sidenav.Header>
                <Sidenav.Body>
                    <Nav>
                        <Nav.Item
                            eventKey="1"
                            active
                            icon={<Icon icon="dashboard" />}
                        >
                            Dashboard
                        </Nav.Item>
                        <Nav.Item eventKey="2" icon={<Icon icon="group" />}>
                            User Group
                        </Nav.Item>
                        <Dropdown
                            eventKey="3"
                            trigger="hover"
                            title="Advanced"
                            icon={<Icon icon="magic" />}
                            placement="rightStart"
                        >
                            <Dropdown.Item eventKey="3-1">Geo</Dropdown.Item>
                            <Dropdown.Item eventKey="3-2">
                                Devices
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="3-3">Brand</Dropdown.Item>
                            <Dropdown.Item eventKey="3-4">
                                Loyalty
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="3-5">
                                Visit Depth
                            </Dropdown.Item>
                        </Dropdown>
                        <Dropdown
                            eventKey="4"
                            trigger="hover"
                            title="Settings"
                            icon={<Icon icon="gear-circle" />}
                            placement="rightStart"
                        >
                            <Dropdown.Item eventKey="4-1">
                                Applications
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="4-2">
                                Websites
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="4-3">
                                Channels
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="4-4">Tags</Dropdown.Item>
                            <Dropdown.Item eventKey="4-5">
                                Versions
                            </Dropdown.Item>
                        </Dropdown>
                    </Nav>
                </Sidenav.Body>
            </Sidenav>
            <NavToggle expand={expand} onChange={handleToggle} />
        </Sidebar>
    );
};

export default ExamSidebar;
