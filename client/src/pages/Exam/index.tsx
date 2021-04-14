import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { Container, Content, Header, Sidebar, Nav, Icon, Navbar, Loader } from 'rsuite';

import ExamService from '../../services/examService';

import IExam from '../../models/IExam';
import Question from '../../components/Question';

interface ParamTypes {
    id: string;
}

const ExamPage = () => {
    const [selectedId, setSelectedId] = useState<number>();

    const [exam, setExam] = useState<IExam>();
    const { id } = useParams<ParamTypes>();

    useEffect(() => {
        ExamService.getById(id).then((res) => {
            setExam(res.data);
            setSelectedId(res.data?.questions[0].id);
        });
    }, []);

    if (!exam) {
        return (
            <Loader size="lg" center/>
        );
    }

    return (
        <div className="show-fake-browser sidebar-page">
            <Container>
                <Header>
                    <Navbar appearance="inverse">
                        <Navbar.Body>
                            <Nav>
                                <Link to="/">
                                    <Nav.Item icon={<Icon icon="home" />}>
                                        Home
                                    </Nav.Item>
                                </Link>
                            </Nav>
                            <Nav pullRight>
                                <Nav.Item icon={<Icon icon="cog" />}>
                                    Settings
                                </Nav.Item>
                            </Nav>
                        </Navbar.Body>
                    </Navbar>
                </Header>
                <Container>
                    <Sidebar>
                        <Nav
                            vertical
                            appearance="tabs"
                            style={{ marginLeft: 15 }}
                        >
                            {exam?.questions.map((q, index) => {
                                return (
                                    <Nav.Item
                                        eventKey="solutions"
                                        active={selectedId === q.id}
                                        onSelect={() => setSelectedId(q.id)}
                                    >
                                        Question {index + 1}
                                    </Nav.Item>
                                );
                            })}
                        </Nav>
                    </Sidebar>
                    <Content style={{ marginLeft: 20 }}>
                        <Question id={selectedId}></Question>
                    </Content>
                </Container>
            </Container>
        </div>
    );
};

export default ExamPage;
