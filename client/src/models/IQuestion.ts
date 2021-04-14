import IAnswer from "./IAnswer";

export default interface IQuestion {
    id: number;
    title: string;
    type: string;
    answers: IAnswer[];
}