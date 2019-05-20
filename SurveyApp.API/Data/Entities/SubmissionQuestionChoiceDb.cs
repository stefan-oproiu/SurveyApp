using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data.Entities
{
    public class SubmissionQuestionChoiceDb
    {
        public int SubmissionId { get; set; }
        public int QuestionChoiceId { get; set; }
        public SubmissionDb Submission { get; set; }
        public QuestionChoiceDb QuestionChoice { get; set; }
    }
}
