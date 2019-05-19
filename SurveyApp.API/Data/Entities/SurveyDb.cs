using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data.Entities
{
    public class SurveyDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SurveyQuestionDb> Questions { get; set; }
        public List<SubmissionDb> Submissions { get; set; }
    }
}
