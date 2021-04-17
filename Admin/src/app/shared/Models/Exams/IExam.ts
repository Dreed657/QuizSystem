import { IQuestion } from "../Questions/IQuestion";

export interface IExam {
    id: Number;
    name: String;
    entryCode: String;
    duration: String;
    questions: IQuestion[];
}