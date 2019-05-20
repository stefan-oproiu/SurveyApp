using SurveyApp.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Models
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public List<ChoiceResponse> Choices { get; set; }
        public QuestionTypeDb Type { get; set; }
    }

    public class ChoiceResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
