import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import {
    Container,
    Content,
    Header,
    Sidebar,
    Nav,
    Icon,
    Navbar,
    Loader,
} from 'rsuite';

import ExamService from '../../services/examService';

import IExam from '../../models/IExam';
import Question from '../../components/Question';
import Countdown from 'react-countdown';
import timespanConverter from '../../utils/timespanConverter';

interface ParamTypes {
    id: string;
}

const ExamPage = () => {
    const [selectedId, setSelectedId] = useState<number>();
    const [duration, setDuration] = useState<Date>();

    const [exam, setExam] = useState<IExam>();
    const { id } = useParams<ParamTypes>();

    useEffect(() => {
        ExamService.getById(id).then((res) => {
            setDuration(
                timespanConverter.convertFromStringInMs(res.data.durationInMs ?? '')
            );
            setExam(res.data);
            setSelectedId(res.data?.questions[0].id);
        });
    }, []);

    // console.log('Duration: ', duration?.valueOf());

    const ranOutOfTime = (): void => {
        console.log('DONE');
    };

    if (!exam) {
        return <Loader size="lg" center />;
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
                                <Nav.Item icon={<Icon icon="clock-o" />}>
                                    <Countdown
                                        date={duration}
                                        intervalDelay={0}
                                        precision={3}
                                        zeroPadTime={2}
                                        onComplete={ranOutOfTime}
                                    />
                                </Nav.Item>
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
                                        key={index}
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
