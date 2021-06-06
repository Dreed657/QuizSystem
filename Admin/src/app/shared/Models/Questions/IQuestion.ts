import { IAnswer } from '../Answers/IAnswer';

export interface IQuestion {
    id: Number;
    title: String;
    type: Number;
    answers: IAnswer[];
}
