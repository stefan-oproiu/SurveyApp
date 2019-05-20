using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Models
{
    public class SubmissionResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public List<QuestionResponse> Questions { get; set; }
    }
}
