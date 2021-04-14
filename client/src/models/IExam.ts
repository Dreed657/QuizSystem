import IShortQuestion from "./IShortQuestion";

export default interface IExam {
    id: number;
    name: string;
    entryCode: string;
    questions: IShortQuestion[];
}