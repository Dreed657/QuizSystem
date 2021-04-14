import React from 'react';

import { Checkbox } from 'rsuite';

import IAnswer from '../../models/IAnswer';
const Answer = (props: { answer: IAnswer }) => {
    return (
        <div>
            <Checkbox> {props.answer.content} </Checkbox>
        </div>
    );
};

export default Answer;
