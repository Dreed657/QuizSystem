import React from 'react';

interface IExam {
    id: number;
    name: string;
    questions: number;
}

const ExamShort = (props: IExam) => {
    return (
        <div key={props.id}>
            <h3>{props.name}</h3>
            <sub>Id: {props.id}</sub>
            <p>Questions: {props.questions}</p>
        </div>
    );
};

export default ExamShort;
