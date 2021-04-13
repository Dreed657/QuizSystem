import React, { useState } from 'react';
import { Toggle, Sidenav, Nav, Icon, Dropdown } from 'rsuite';

const ExamSidebar = () => {
    const [expanded, setExpanded] = useState(true);
    const [activeKey, setActiveKey] = useState('');

    const handleToggle = () => {
        setExpanded(!expanded);
    }

    const handleSelect = (eventKey: any) => {
        setActiveKey(eventKey);
    }

    return (
        <div style={{ width: 250 }}>
            <Toggle onChange={handleToggle} checked={expanded} />
            <hr />
            <Sidenav
                expanded={expanded}
                defaultOpenKeys={['3', '4']}
                activeKey={activeKey}
                onSelect={handleSelect}
            >
                <Sidenav.Body>
                    <Nav>
                        <Nav.Item eventKey="1" icon={<Icon icon="dashboard" />}>
                            Dashboard
                        </Nav.Item>
                        <Nav.Item eventKey="2" icon={<Icon icon="group" />}>
                            User Group
                        </Nav.Item>
                        <Dropdown
                            placement="rightStart"
                            eventKey="3"
                            title="Advanced"
                            icon={<Icon icon="magic" />}
                        >
                            <Dropdown.Item eventKey="3-1">Geo</Dropdown.Item>
                            <Dropdown.Item eventKey="3-2">
                                Devices
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="3-3">
                                Loyalty
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="3-4">
                                Visit Depth
                            </Dropdown.Item>
                        </Dropdown>
                        <Dropdown
                            placement="rightStart"
                            eventKey="4"
                            title="Settings"
                            icon={<Icon icon="gear-circle" />}
                        >
                            <Dropdown.Item eventKey="4-1">
                                Applications
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="4-2">
                                Channels
                            </Dropdown.Item>
                            <Dropdown.Item eventKey="4-3">
                                Versions
                            </Dropdown.Item>
                            <Dropdown.Menu eventKey="4-5" title="Custom Action">
                                <Dropdown.Item eventKey="4-5-1">
                                    Action Name
                                </Dropdown.Item>
                                <Dropdown.Item eventKey="4-5-2">
                                    Action Params
                                </Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                    </Nav>
                </Sidenav.Body>
            </Sidenav>
        </div>
    );
};

export default ExamSidebar;
