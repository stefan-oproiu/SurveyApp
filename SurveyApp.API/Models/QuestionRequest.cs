using Microsoft.AspNetCore.Http;
using SurveyApp.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Models
{
    public class QuestionRequest
    {
        public string Text { get; set; }
        public IFormFile File { get; set; }

        public List<ChoiceResponse> Choices { get; set; }
        public QuestionTypeDb Type { get; set; }
    }
}
