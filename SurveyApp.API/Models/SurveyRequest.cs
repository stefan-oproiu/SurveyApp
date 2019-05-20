using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Models
{
    public class SurveyRequest
    {
        public string Name { get; set; }
        public List<int> QuestionIds { get; set; }
    }
}
