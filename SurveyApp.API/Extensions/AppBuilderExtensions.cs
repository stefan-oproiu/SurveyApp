using Microsoft.AspNetCore.Builder;
using SurveyApp.API.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionResponse(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
