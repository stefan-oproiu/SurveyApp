import { QuestionResponse } from './question.model';

export interface SurveyRequest {
    name: string;
    questionIds: number[];
}

export interface SurveyResponse {
    id: number;
    name: string;
    questions: QuestionResponse[];
}