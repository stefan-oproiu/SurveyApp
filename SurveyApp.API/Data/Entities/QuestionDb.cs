using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data.Entities
{
    public class QuestionDb
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public List<QuestionChoiceDb> Choices { get; set; }
        public List<SurveyQuestionDb> Surveys { get; set; }
        public QuestionTypeDb Type { get; set; }
    }
}
