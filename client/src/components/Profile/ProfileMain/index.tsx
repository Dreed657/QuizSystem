import React from 'react';

import { Container, Panel, PanelGroup } from 'rsuite';
import IExamAttempts from '../../../models/IExamAttempts';

interface ProfileMainProps {
    exams?: IExamAttempts[];
    avgGPA?: number;
}

const ProfileMain = (props: ProfileMainProps) => {
    return (
        <Container>
            <h3>Profile Page.</h3>
            <p>avgGPA: {props.avgGPA}</p>
            <PanelGroup>
                {props.exams?.map((exam) => {
                    return (
                        <Panel header={exam.examName}>
                            <p>Id: {exam.id}</p>
                            <p>Date: {exam.startTime}</p>
                            <p>Score: {exam.score}</p>
                            <p>CorrectAnswers: {exam.correctAnswers}</p>
                            <p>WrongAnswers: {exam.wrongAnswers}</p>
                        </Panel>
                    );
                })}
            </PanelGroup>
        </Container>
    );
};

export default ProfileMain;
