export interface QuestionRequest {
    text: string;
    file: File;
    choices: ChoiceResponse[];
    type: QuestionType;
}

export interface ChoiceResponse {
    id: number;
    text: string;
}

export interface QuestionResponse {
    id: number;
    text: string;
    imageUrl: string;
    type: QuestionType;
    choices: ChoiceResponse[];
}

export enum QuestionType {
    singleChoice = 0,
    multipleChoice = 1
}