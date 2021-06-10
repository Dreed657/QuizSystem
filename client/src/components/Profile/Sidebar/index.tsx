import React from 'react';

import { Sidebar } from 'rsuite';

interface ProfileSidebarProps {
    firstName?: string;
    lastName?: string;
    userName?: string;
    email?: string;
}

const ProfileSidebar = (props: ProfileSidebarProps) => {
    return (
        <Sidebar>
            <h3>Name</h3>
            <p>{props.firstName} {props.lastName}</p>
            <sub>{props.userName}</sub>
            <h3>Email</h3>
            <p>{props.email}</p>
        </Sidebar>
    );
};

export default ProfileSidebar;
