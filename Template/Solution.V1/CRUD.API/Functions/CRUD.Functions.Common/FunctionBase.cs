using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PPT.Functions.Common
{
    public class FunctionBase : IFunctionExceptionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected FunctionBase(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task OnExceptionAsync(FunctionExceptionContext context, CancellationToken cancellationToken)
        {
            var error = new DTO.Error();
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception.InnerException is SqlException)
            {
                var exception = context.Exception as SqlException;
                statusCode = HttpStatusCode.BadRequest;
                error.Message = exception.Message;
            }
            else if (context.Exception.InnerException is PPT.Services.Common.Exceptions.UnauthorizedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                error.Message = $"Access Denied: {context.Exception.InnerException.Message}";
            }
            else
            {
                error.Message = context.Exception.GetBaseException().Message;
            }
            error.Code = (int)statusCode;

            var response = _httpContextAccessor.HttpContext.Response;

            var funHelper = new FunctionHelper();
            var result = funHelper.CreateResult(statusCode, error);

            await writeResponse(response, result, error, cancellationToken);
        }

        private async Task writeResponse(HttpResponse response, ObjectResult result, DTO.Error error, CancellationToken cancellationToken)
        {
            response.StatusCode = (int)result.StatusCode;
            response.ContentType = "application/json";
            foreach (var header in response.Headers)
            {
                if (!response.Headers.ContainsKey(header.Key))
                {
                    response.Headers.Add(header);
                }
            }

            var text = JsonSerializer.Serialize(error);

            await _httpContextAccessor.HttpContext.Response.WriteAsync(text);
            _httpContextAccessor.HttpContext.Response.ContentLength = text.Length;
        }
    }
}
