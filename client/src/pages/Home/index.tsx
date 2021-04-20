import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router';

import { Container, Content, Loader, Panel, Button } from 'rsuite';

import MasterHeader from '../../components/Header';
import IShortExam from '../../models/IShortExam';

import ExamService from '../../services/examService';

const HomePage = () => {
    const [exams, setExams] = useState<IShortExam[]>();

    const history = useHistory();

    useEffect(() => {
        ExamService.getAll().then((res) => {
            setExams(res.data);
        });
    }, []);

    const startHanlder = (examId: string) => {
        ExamService.start(examId)
            .then((x) => {
                console.log(x);
                history.push(`/exam/${examId}`);
            })
            .then((x) => console.warn(x));
    };

    if (!exams) {
        return <Loader size="lg" content="Loading...." center></Loader>;
    }

    return (
        <Container>
            <MasterHeader></MasterHeader>
            <Content>
                {exams.map((exam) => {
                    return (
                        <Panel
                            style={{ margin: 20 }}
                            key={exam.id}
                            header={exam.name}
                            bordered
                        >
                            <sub>Id: {exam.id}</sub>
                            <p>Duration: {exam.duration}</p>
                            <p>Questions: {exam.questions}</p>
                            <Button
                                appearance="primary"
                                size="md"
                                style={{ marginTop: 10, marginBottom: 10 }}
                                onClick={() => startHanlder(exam.id.toString())}
                            >
                                Start
                            </Button>
                        </Panel>
                    );
                })}
            </Content>
        </Container>
    );
};

export default HomePage;
