﻿using HospitalManagement.Business.Interfaces;
using HospitalManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HospitalManagent.Service
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
            
        }

        public async Task InvokeAsync(HttpContext httpContext, IErrorService errorService)
        {
            try
            {
                await next(httpContext);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, errorService);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IErrorService errorService)
        {
            context.Response.ContentType = "application/json";
            string errorMessage;
            switch (exception)
            {
                case KeyNotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorMessage = "Item does not exist in the collection";
                    break;
                case NullReferenceException nullError:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = "Null Reference";
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = "Internal Server Error from middleware";
                    break;
            }
            ErrorDetails error = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = errorMessage
            };
            await context.Response.WriteAsync(error.ToString());

            errorService.Insert(errorService.CreateError("",error.Message));

        }

    }
}
