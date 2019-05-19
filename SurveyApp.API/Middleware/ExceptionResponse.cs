using System.Collections.Generic;

namespace SurveyApp.API.Middleware
{
    internal class ExceptionResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}