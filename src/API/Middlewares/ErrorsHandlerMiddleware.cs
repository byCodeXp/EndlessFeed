using System;
using System.Net;
using System.Threading.Tasks;
using API.Contracts.Responses.v1;
using API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Middlewares
{
    public class ErrorsHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorsHandlerMiddleware> _logger;

        public ErrorsHandlerMiddleware(RequestDelegate next, ILogger<ErrorsHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                string message = null;
                
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                
                switch (exception)
                {
                    case BadRequestRestException:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        message = exception.Message;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        message = "Internal Server Error";
                        break;
                }

                _logger.LogError(exception.ToString());

                await response.WriteAsync(new FailedResponseV1
                {
                    Code = response.StatusCode,
                    Message = message
                }.ToString());
            }
        }
    }
}