import IExamAttempts from "./IExamAttempts";

export default interface IProfile {
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    avgGPA: number;
    exams: IExamAttempts[];
}