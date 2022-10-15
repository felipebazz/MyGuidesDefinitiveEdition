using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using MyGuides.Notifications.Result;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MyGuides.Notifications.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            SetInternalServerError(context);

            var notification = new Notification(context.Exception.InnerException?.Message ?? context.Exception.Message);

            var requestResult = new RequestResult
            {
                Success = false,
                Messages = new List<Notification> { notification }
            };

            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(requestResult));
        }

        private void SetInternalServerError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}
