using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoPrint.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PPT.PhotoPrint.API.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new DTO.Error();
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError; 

            if(context.Exception is SqlException)
            {
                var exception = context.Exception as SqlException;
                statusCode = HttpStatusCode.BadRequest;
                error.Message = exception.Message;
            }
            else if(context.Exception is UnauthorizedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                error.Message = $"Access Denied: {context.Exception.Message}";
            }
            else
            {                
                error.Message = context.Exception.GetBaseException().Message;
            }

            error.Code = (int)statusCode;

            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new ObjectResult(new { statusCode = statusCode, currentDate = DateTime.Now, response = JsonSerializer.Serialize(error) });

            base.OnException(context);
        }
    }
}
