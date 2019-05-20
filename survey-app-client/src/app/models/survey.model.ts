import { QuestionResponse } from './question.model';

export interface SurveyRequest {
    name: string;
    questionIds: number[];
}

export interface SurveyResponse {
    name: string;
    questions: QuestionResponse[];
}