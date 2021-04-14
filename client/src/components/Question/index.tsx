import React, { useEffect, useState } from 'react';

import { Placeholder, Panel, Loader } from 'rsuite';

import Answer from '../Answer';

import QuestionService from '../../services/questionService';
import IQuestion from '../../models/IQuestion';

const Question = (props: { id: number | undefined }) => {
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
            {question.answers.map((answer) => {
                return <Answer answer={answer} />;
            })}
        </Panel>
    );
};

export default Question;
