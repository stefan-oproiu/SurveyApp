import { QuestionResponse } from './question.model';

export interface SubmissionRequest {
    userId: number;
    surveyId: number;
    questionChoicesIds: number[];
}

export interface SubmissionResponse {
    id: number;
    userId: number;
    surveyId: number;
    questions: QuestionResponse[];
}