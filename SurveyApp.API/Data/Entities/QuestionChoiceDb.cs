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
        public List<SubmissionQuestionChoice> Submissions { get; set; }
    }
}
