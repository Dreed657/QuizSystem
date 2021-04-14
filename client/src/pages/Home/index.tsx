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
                            <p>Questions: {exam.questions}</p>
                            <Button
                                appearance="primary"
                                size="md"
                                style={{ marginTop: 10, marginBottom: 10 }}
                                onClick={() => history.push(`/exam/${exam.id}`)}
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
