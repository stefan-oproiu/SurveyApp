namespace SurveyApp.API.Data.Entities
{
    public class SurveyQuestionDb
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public QuestionDb Question { get; set; }
        public SurveyDb Survey { get; set; } 
    }
}
