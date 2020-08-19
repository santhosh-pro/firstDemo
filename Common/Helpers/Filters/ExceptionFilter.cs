using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace firstDemo.Common.Helpers.Filters
{
     public class ExceptionFilter : IExceptionFilter {
        public void OnException (ExceptionContext context) {
            var applicationException = context.Exception as UseCaseException;
            if (applicationException != null) {
                var json = JsonConvert.SerializeObject (applicationException.BusinessMessage);

                context.Result = new BadRequestObjectResult (json);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }

           

            var domainException = context.Exception as DomainException;
            if (domainException != null) {
                string json = JsonConvert.SerializeObject (domainException.BusinessMessage);

                context.Result = new BadRequestObjectResult (json);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
    }
}