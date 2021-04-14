import React from 'react';

import { Container, Content, Header } from 'rsuite';
import ExamSidebar from '../../components/ExamSidebar/Index';

const ExamPage = () => {
    return (
        <div className="show-fake-browser sidebar-page">
            <Container>
                <ExamSidebar />

                <Container>
                    <Header>
                        <h2>Page Title</h2>
                    </Header>
                    <Content>Content</Content>
                </Container>
            </Container>
        </div>
    );
};

export default ExamPage;
