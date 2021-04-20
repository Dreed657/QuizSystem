import React from 'react';

import { Checkbox, Radio } from 'rsuite';

import IAnswer from '../../models/IAnswer';
import answerService from '../../services/answerService';

interface IProps {
    answers: IAnswer[];
    questionId: number;
    examId: number;
    type: string;
}

const Answers = (props: IProps) => {
    const saveAnswer = (answerId: number) => {
        let data = {
            answerId,
            questionId: props.questionId,
            examId: props.examId,
        };

        console.log('Ready data: ', data);

        answerService
            .saveAnswer(data)
            .then((x) => console.log(x))
            .catch((x) => console.warn(x));
    };

    if (props.type !== 'MultiChoice') {
        return (
            <div>
                {props.answers.map((x) => {
                    return (
                        <Checkbox
                            key={x.id}
                            value={x.id}
                            onChange={(e) => saveAnswer(e)}
                        >
                            {x.content}
                        </Checkbox>
                    );
                })}
            </div>
        );
    } else {
        return (
            <div>
                {props.answers.map((x) => {
                    return (
                        <Radio
                            key={x.id}
                            value={x.id}
                            onChange={(e) => saveAnswer(e)}
                        >
                            {x.content}
                        </Radio>
                    );
                })}
            </div>
        );
    }
};

export default Answers;
