using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data.Entities
{
    public class QuestionChoiceDb
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public QuestionDb Question { get; set; }
        public List<SubmissionQuestionChoiceDb> Submissions { get; set; }
    }
}
