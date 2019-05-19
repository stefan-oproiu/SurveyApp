using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data.Entities
{
    public class SubmissionDb
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDb User { get; set; }
        public int SurveyId { get; set; }
        public SurveyDb Survey { get; set; }
        public List<SubmissionQuestionChoice> Choices { get; set; }
    }
}
