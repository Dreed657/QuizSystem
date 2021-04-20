import React, { FormEvent, useEffect, useState } from 'react';

import { Placeholder, Panel } from 'rsuite';

import QuestionService from '../../services/questionService';
import IQuestion from '../../models/IQuestion';
import Answers from '../Answers';

const Question = (props: { id: number | undefined; examId: number }) => {
    const { Paragraph } = Placeholder;

    const [question, setQuestion] = useState<IQuestion>();

    useEffect(() => {
        setQuestion(undefined);

        if (props.id) {
            QuestionService.getById(props.id).then((res) => {
                setQuestion(res.data);
            });
        } else {
            return;
        }
    }, [props]);

    if (!question) {
        return (
            <div>
                <Paragraph active></Paragraph>
                <Paragraph
                    style={{ marginTop: 10 }}
                    graph="square"
                    active
                ></Paragraph>
            </div>
        );
    }

    return (
        <Panel header={question.title}>
            <p>{question.type}</p>

            <Answers
                answers={question.answers}
                type={question.type}
                examId={props.examId}
                questionId={question.id}
            />
        </Panel>
    );
};

export default Question;
