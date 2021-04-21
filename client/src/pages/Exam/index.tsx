import React, { useContext, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
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
import examService from '../../services/examService';

import GlobalContext from '../../contexts/GlobalContext';

interface ParamTypes {
    id: string;
}

const ExamPage = () => {
    const [selectedId, setSelectedId] = useState<number>();
    const [duration, setDuration] = useState<Date>();

    const [exam, setExam] = useState<IExam>();
    const { id } = useParams<ParamTypes>();

    const history = useHistory();
    const context = useContext(GlobalContext);

    useEffect(() => {
        ExamService.getById(id).then((res) => {
            setDuration(
                timespanConverter.convertFromStringInMs(
                    res.data.durationInMs ?? ''
                )
            );
            setExam(res.data);
            setSelectedId(res.data?.questions[0].id);
        });
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const ranOutOfTime = (): void => {
        console.log('DONE');
    };

    const finishHandler = (examId: string): void => {
        examService
            .finish(examId)
            .then((x) => {
                console.log(x.data);
                context.examAttemptId = null;
                history.push(`/`);
            })
            .catch((x) => console.warn(x));
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
                                <Nav.Item>Id: {exam.id}</Nav.Item>
                                <Nav.Item>Name: {exam.name}</Nav.Item>
                                <Nav.Item>AttemptId: {context.examAttemptId}</Nav.Item>
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
                                <Nav.Item
                                    onClick={() =>
                                        finishHandler(exam.id.toString())
                                    }
                                >
                                    Finish
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
                                        icon={
                                            selectedId === q.id ? (
                                                <Icon
                                                    icon="check"
                                                    style={{ color: '#1f7505' }}
                                                />
                                            ) : (
                                                <i></i>
                                            )
                                        }
                                    >
                                        Question {index + 1}
                                    </Nav.Item>
                                );
                            })}
                        </Nav>
                    </Sidebar>
                    <Content style={{ marginLeft: 20 }}>
                        <Question id={selectedId} examId={exam.id}></Question>
                    </Content>
                </Container>
            </Container>
        </div>
    );
};

export default ExamPage;
