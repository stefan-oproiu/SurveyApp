using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SurveyApp.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.API.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (NotFoundException aex)
            {
                _logger.LogError(aex, "Error");
                await WriteErrorMessage(context, aex, StatusCodes.Status400BadRequest);
            }
            catch (BadRequestException avex)
            {
                _logger.LogError(avex, "Error");
                await WriteErrorMessage(context, avex, StatusCodes.Status400BadRequest);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogError(ex, "Error");
                await WriteErrorMessage(context, ex, StatusCodes.Status401Unauthorized);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                await WriteErrorMessage(context, ex, StatusCodes.Status500InternalServerError);
            }

        }

        private static async Task WriteErrorMessage(HttpContext context, Exception ex, int responseCode)
        {
            var errors = new List<string>() { ex.Message };
            if (ex is BadRequestException)
            {
                errors = ex.Message.Split(",").ToList();
                await WriteErrorToContext(context, errors, "Validation Errors", responseCode);
            }
            else
            {
                await WriteErrorToContext(context, errors, ex.Message, responseCode);
            }


        }


        private static async Task WriteErrorToContext(HttpContext context,
            List<string> errors,
            string message,
            int responseCode)
        {
            var errorMessage = JsonConvert.SerializeObject(
                new ExceptionResponse
                {

                    Message = message,
                    Errors = errors
                }
                );

            context.Response.StatusCode = responseCode;

            var errorMessageUtf8 = Encoding.UTF8.GetBytes(errorMessage);
            context.Response.ContentType = "application/json";

            await context.Response.Body.WriteAsync(errorMessageUtf8, 0, errorMessageUtf8.Length).ConfigureAwait(false);
        }
    }
}
