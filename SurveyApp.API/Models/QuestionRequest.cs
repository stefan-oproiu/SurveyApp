using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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

        public List<ChoiceRequest> Choices { get; set; }
        public QuestionTypeDb Type { get; set; }
    }

    public class ChoiceRequest
    {
        public string Text { get; set; }
    }
}
