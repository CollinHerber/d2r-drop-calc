using D2RDropCalc.Server.Models.DTOs.Error;
using D2RDropCalc.Server.Models.DTOs.Error.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace D2RDropCalc.Server.Api.Lib.Middleware {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next) {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IHttpContextAccessor httpContentAccessor) {
            try {
                await next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is InvalidOperationException 
                     || exception is InvalidCredentialException
                     || exception is InvalidDataException)
            {
                code = HttpStatusCode.BadRequest;
            } 

            var reason = ErrorReason.InvalidData;
          

            var errorResponse = new ErrorResponse(exception.Message, reason);

            if (exception is DbUpdateException)
            {
                errorResponse.Reason = ErrorReason.ValidationError;
                errorResponse.Details = exception.InnerException.Message;
                code = HttpStatusCode.BadRequest;
            }
            

            var result = JsonConvert.SerializeObject(errorResponse, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
