import IShortQuestion from "./IShortQuestion";

export default interface IExam {
    id: number;
    name: string;
    entryCode: string;
    duration: String;
    questions: IShortQuestion[];
}