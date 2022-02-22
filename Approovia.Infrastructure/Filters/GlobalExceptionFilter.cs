


using Approovia.Core.ApiResponse;
using Approovia.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Approovia.Core.Utility.Constants;

namespace Approovia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //   Log<GlobalExceptionFilter>.LogError(context.Exception);
            HttpResponse response = context.HttpContext.Response;
            var content = GetStatusCode<object>(context.Exception);

            if (!context.HttpContext.Response.HasStarted)
            {
                response.StatusCode = (int)content.Item2;
                response.ContentType = "application/json";
                context.Result = new JsonResult(content.Item1);
            }
        }

        public static (ResponseModel<T> responseModel, HttpStatusCode statusCode) GetStatusCode<T>(Exception exception)
        {
            switch (exception)
            {
                case BaseException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = bex.Code,
                        Message = bex.Message,
                        RequestSuccessful = false
                    }, bex.httpStatusCode);
                //case SecurityTokenExpiredException bex:
                //    return (new ResponseModel<T>
                //    {
                //        ResponseCode = ResponseCodes.TokenExpired,
                //        Message = "Session expired",
                //        RequestSuccessful = false,
                //    }, HttpStatusCode.Unauthorized);
                //case SecurityTokenValidationException bex:
                //    return (new ResponseModel<T>
                //    {
                //        ResponseCode = ResponseCodes.TokenValidationFailed,
                //        Message = "Invalid authentication parameters",
                //        RequestSuccessful = false,
                //    }, HttpStatusCode.Unauthorized);
                case ValidationException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = ResponseCodes.ModelValidation,
                        Message = bex.Message,
                        RequestSuccessful = false
                    }, HttpStatusCode.BadRequest);
                default:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = ResponseCodes.Failed,
                        Message = exception.Message,
                        RequestSuccessful = false
                    }, HttpStatusCode.InternalServerError);
            }
        }
    }


}

