using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Models
{
    public class SurveyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionResponse> Questions { get; set; }
    }
}
