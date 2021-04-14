import React, { useEffect, useState } from 'react';

import {
    Container,
    Content,
    Header,
    Loader,
    Panel,
    PanelGroup,
    Placeholder,
} from 'rsuite';
import ExamShort from '../../components/ShortExam/Index';

import ExamService from '../../services/examService';

interface IExam {
    id: number;
    name: string;
    questions: number;
}

const HomePage = () => {
    const { Paragraph } = Placeholder;
    const [exams, setExams] = useState<IExam[]>();

    useEffect(() => {
        ExamService.getAll().then((res) => {
            setExams(res.data);
            console.log(exams);
        });
    }, []);

    if (!exams) {
        return <Loader size="lg" content="Loading...."></Loader>;
    }

    return (
        <Container>
            <Header>
                <h3>Home page.</h3>
            </Header>
            <Content>
                {exams.map((exam) => {
                    return (
                        <div key={exam.id}>
                            <h3>{exam.name}</h3>
                            <sub>Id: {exam.id}</sub>
                            <p>Questions: {exam.questions}</p>
                        </div>
                    );
                })}
            </Content>
        </Container>
    );
};

export default HomePage;
