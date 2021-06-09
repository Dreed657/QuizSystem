export default interface IExamAttempts {
    id: number;
    userId: string;
    userName: string;
    examName: string;
    startTime: Date;
    score: number;
    correctAnswers: number;
    wrongAnswers: number;
}