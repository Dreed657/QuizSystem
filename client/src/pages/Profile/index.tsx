import React, { useEffect, useState } from 'react';

import { Container, Loader } from 'rsuite';

import MasterHeader from '../../components/Header';
import MainProfile from '../../components/Profile/ProfileMain';
import ProfileSidebar from '../../components/Profile/Sidebar';

import IProfile from '../../models/IProfile';
import profileService from '../../services/profileService';

const ProfilePage = () => {
    const [profileData, setProfileData] = useState<IProfile | undefined>(undefined);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        setIsLoading(true);
        profileService.getProfile().then((res) => {
            console.log(res);
            setProfileData(res.data);
            setIsLoading(false);
        });
    }, []);

    if (isLoading) {
        return <Loader size="lg" content="Loading...." center></Loader>;
    }

    return (
        <div>
            <MasterHeader></MasterHeader>
            <Container fluid>
                <ProfileSidebar {...profileData}></ProfileSidebar>
                <MainProfile {...profileData}></MainProfile>
            </Container>
        </div>
    );
};

export default ProfilePage;
