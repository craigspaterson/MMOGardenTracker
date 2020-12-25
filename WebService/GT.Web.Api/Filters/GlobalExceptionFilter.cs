using GT.Common.Exceptions;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.Json;

namespace GT.Web.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                return;
            }

            int statusCode;

            var exception = context.Exception;
            switch (exception)
            {
                case ArgumentNullException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case ArgumentOutOfRangeException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case ArgumentException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case BadRequestException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException _:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case ConflictException _:
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var response = context.HttpContext.Response;
            response.StatusCode = statusCode;
            response.ContentType = "application/json";

            var errorDetails = new ErrorDetails
            {
                Message = exception.Message,
                StatusCode = statusCode
            };

            var json = JsonSerializer.Serialize(errorDetails);

            response.WriteAsync(json);
        }
    }
}